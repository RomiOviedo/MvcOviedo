using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcOviedo.Entidades;
using MvcOviedo.Servicios.Interfaces;
using MvcOviedo.WEB.ViewModels.Genre;
using X.PagedList.Extensions;

namespace MvcOviedo.WEB.Controllers
{
    public class GenreController : Controller
    {
        private readonly IServicioGenre? servicio;
        private readonly IMapper? _mapper;

        public GenreController(IServicioGenre? servicio, IMapper? mapper)
        {
            this.servicio = servicio;
            _mapper = mapper;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;
            var Genres = servicio?.GetAll
                (orderBy: o => o.OrderBy(c => c.GenreName));
            var GenresVm = _mapper?.Map<List<GenreListVm>>(Genres)
                .ToPagedList(pageNumber, pageSize);
            return View(GenresVm);

        }
        public IActionResult UpSert(int? id)
        {
            if (servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            GenreEditVm GenreVm;
            if (id == null || id == 0)
            {
                GenreVm = new GenreEditVm();
            }
            else
            {
                try
                {
                    Genre? Genre = servicio.Get(filter: g => g.GenreId == id);
                    if (Genre == null)
                    {
                        return NotFound();
                    }
                    GenreVm = _mapper.Map<GenreEditVm>(Genre);
                    return View(GenreVm);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(GenreVm);

        }


        [HttpPost]
        public IActionResult UpSert(GenreEditVm GenreVm)
        {
            if (!ModelState.IsValid)
            {
                return View(GenreVm);
            }

            if (servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Genre Genre = _mapper.Map<Genre>(GenreVm);

                if (servicio.Existe(Genre))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(GenreVm);
                }

                servicio.Save(Genre);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(GenreVm);
            }
        }

        //[HttpDelete]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Genre? Genre = servicio?.Get(filter: g => g.GenreId == id);
            if (Genre is null)
            {
                return NotFound();
            }
            try
            {
                if (servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }
                if (servicio.EstaRelacionado(Genre.GenreId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                servicio.Delete(Genre);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;
            }
        }



    }
}

