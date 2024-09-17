using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Servicios.Interfaces
{
    public interface IServicioSport
    {

        IEnumerable<Sport>? GetAll(Expression<Func<Sport, bool>>? filter = null,
    Func<IQueryable<Sport>, IOrderedQueryable<Sport>>? orderBy = null,
    string? propertiesNames = null);
        void Save(Sport Sport);
        void Delete(Sport Sport);
        Sport? Get(Expression<Func<Sport, bool>>? filter = null,
            string? propertiesNames = null,
            bool tracked = true);
        bool Existe(Sport Sport);
        bool EstaRelacionado(int id);

    }
}
