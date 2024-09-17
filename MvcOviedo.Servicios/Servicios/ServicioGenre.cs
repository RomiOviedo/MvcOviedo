using MvcOviedo.Datos.Interfaces;
using MvcOviedo.Datos;
using MvcOviedo.Entidades;
using MvcOviedo.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Servicios.Servicios
{
    public class ServicioGenre : IServicioGenre
    {
        private readonly IRepositorioGenre? _repository;
        private readonly IUnitOfWork? _unitOfWork;

        public ServicioGenre(IRepositorioGenre? repository,
            IUnitOfWork? unitOfWork)
        {
            _repository = repository ?? throw new ArgumentException("Dependencies not set");
            _unitOfWork = unitOfWork ?? throw new ArgumentException("Dependencies not set");
        }

        public void Delete(Genre Genre)
        {
            try
            {
                _unitOfWork!.BeginTransaction();
                _repository!.Delete(Genre);
                _unitOfWork!.Commit();

            }
            catch (Exception)
            {
                _unitOfWork!.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(int id)
        {
            return _repository!.EstaRelacionado(id);
        }


        public bool Existe(Genre Genre)
        {
            return _repository!.Existe(Genre);
        }

        public Genre? Get(Expression<Func<Genre, bool>>? filter = null,
            string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }


        public IEnumerable<Genre> GetAll(Expression<Func<Genre, bool>>? filter = null,
            Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
            string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }


        public void Save(Genre Genre)
        {
            try
            {
                _unitOfWork?.BeginTransaction();
                if (Genre.GenreId == 0)
                {
                    _repository?.Add(Genre);
                }
                else
                {
                    _repository?.Update(Genre);
                }
                _unitOfWork?.Commit();

            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }
    
    }
}
