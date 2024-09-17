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
    public class ServicioColour
: IServicioColour
    {
        private readonly IRepositorioColour? _repository;
        private readonly IUnitOfWork? _unitOfWork;

        public ServicioColour(IRepositorioColour? repository,
            IUnitOfWork? unitOfWork)
        {
            _repository = repository ?? throw new ArgumentException("Dependencies not set");
            _unitOfWork = unitOfWork ?? throw new ArgumentException("Dependencies not set");
        }

        public void Delete(Colour Colour)
        {
            try
            {
                _unitOfWork!.BeginTransaction();
                _repository!.Delete(Colour);
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


        public bool Existe(Colour Colour)
        {
            return _repository!.Existe(Colour);
        }

        public Colour? Get(Expression<Func<Colour, bool>>? filter = null,
            string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }


        public IEnumerable<Colour> GetAll(Expression<Func<Colour, bool>>? filter = null,
            Func<IQueryable<Colour>, IOrderedQueryable<Colour>>? orderBy = null,
            string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }


        public void Save(Colour Colour)
        {
            try
            {
                _unitOfWork?.BeginTransaction();
                if (Colour.ColourId == 0)
                {
                    _repository?.Add(Colour);
                }
                else
                {
                    _repository?.Update(Colour);
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
