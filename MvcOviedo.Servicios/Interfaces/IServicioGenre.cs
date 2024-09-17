using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Servicios.Interfaces
{
    public interface IServicioGenre
    {
        IEnumerable<Genre>? GetAll(Expression<Func<Genre, bool>>? filter = null,
            Func<IQueryable<Genre>, IOrderedQueryable<Genre>>? orderBy = null,
            string? propertiesNames = null);
        void Save(Genre Genre);
        void Delete(Genre Genre);
        Genre? Get(Expression<Func<Genre, bool>>? filter = null,
            string? propertiesNames = null,
            bool tracked = true);
        bool Existe(Genre Genre);
        bool EstaRelacionado(int id);
    }
}
