using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcOviedo.Entidades;
using MvcOviedo.Servicios.Interfaces;
using MvcOviedo.WEB.ViewModels.Brand;
using X.PagedList.Extensions;

namespace MvcOviedo.WEB.Controllers
{
    public class BrandController : Controller
    {
        private readonly IServicioBrand? servicio;
        private readonly IMapper? _mapper;

        public BrandController(IServicioBrand? servicio, IMapper? mapper)
        {
            this.servicio = servicio;
            _mapper = mapper;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 2;
            var Brands = servicio?.GetAll
                (orderBy: o => o.OrderBy(c => c.BrandName));
            var BrandsVm = _mapper?.Map<List<BrandListVm>>(Brands)
                .ToPagedList(pageNumber, pageSize);
            return View(BrandsVm);

        }
        public IActionResult UpSert(int? id)
        {
            if (servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }
            BrandEditVm BrandVm;
            if (id == null || id == 0)
            {
                BrandVm = new BrandEditVm();
            }
            else
            {
                try
                {
                    Brand? brand = servicio.Get(filter: g => g.BrandId == id);
                    if (brand == null)
                    {
                        return NotFound();
                    }
                    BrandVm = _mapper.Map<BrandEditVm>(brand);
                    return View(BrandVm);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the record.");
                }

            }
            return View(BrandVm);

        }


        [HttpPost]
        public IActionResult UpSert(BrandEditVm BrandVm)
        {
            if (!ModelState.IsValid)
            {
                return View(BrandVm);
            }

            if (servicio == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
            }

            try
            {
                Brand Brand = _mapper.Map<Brand>(BrandVm);

                if (servicio.Existe(Brand))
                {
                    ModelState.AddModelError(string.Empty, "Record already exist");
                    return View(BrandVm);
                }

                servicio.Save(Brand);
                TempData["success"] = "Record successfully added/edited";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while editing the record.");
                return View(BrandVm);
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
            Brand? Brand = servicio?.Get(filter: g => g.BrandId == id);
            if (Brand is null)
            {
                return NotFound();
            }
            try
            {
                if (servicio == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }
                if (servicio.EstaRelacionado(Brand.BrandId))
                {
                    return Json(new { success = false, message = "Related Record... Delete Deny!!" }); ;
                }
                servicio.Delete(Brand);
                return Json(new { success = true, message = "Record successfully deleted" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Couldn't delete record!!! " }); ;
            }
        }



    }
}
