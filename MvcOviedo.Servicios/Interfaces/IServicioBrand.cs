using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Servicios.Interfaces
{
    public interface IServicioBrand
    {
        IEnumerable<Brand>? GetAll(Expression<Func<Brand, bool>>? filter = null,
            Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy = null,
            string? propertiesNames = null);
        void Save(Brand Brand);
        void Delete(Brand Brand);
        Brand? Get(Expression<Func<Brand, bool>>? filter = null,
            string? propertiesNames = null,
            bool tracked = true);
        bool Existe(Brand Brand);
        bool EstaRelacionado(int id);
    }
}
