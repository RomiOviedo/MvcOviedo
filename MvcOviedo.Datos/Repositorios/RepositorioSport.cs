using MvcOviedo.Datos.Interfaces;
using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Repositorios
{
    public class RepositorioSport : RepositorioGenerico<Sport>, IRepositorioSport
    {
        private readonly MvcOviedoDbContext _db;
        public RepositorioSport(MvcOviedoDbContext? db) : base(db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool EstaRelacionado(int id)
        {
            return false;
            //return _db.Shoes.Any(p => p.SportId == id);
        }

        public bool Existe(Sport Sport)
        {
            if (Sport.SportId == 0)
            {
                return _db.Sports.Any(s => s.SportName == Sport.SportName);
            }
            return _db.Sports.Any(s => s.SportName == Sport.SportName &&
                    s.SportId != Sport.SportId);
        }

        public bool Existe(Brand Brand)
        {
            throw new NotImplementedException();
        }

        public void Update(Sport Sport)
        {
            _db.Sports.Update(Sport);
        }

        public void Update(Brand Brand)
        {
            throw new NotImplementedException();
        }
    }
}
    
