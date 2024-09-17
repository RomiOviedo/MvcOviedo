using MvcOviedo.Datos.Interfaces;
using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Repositorios
{
    public class RepositorioBrand : RepositorioGenerico<Brand>, IRepositorioBrand
    {
        private readonly MvcOviedoDbContext _db;
        public RepositorioBrand(MvcOviedoDbContext? db) : base(db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool EstaRelacionado(int id)
        {
            return false;
            //return _db.Shoes.Any(p => p.BrandId == id);
        }

        public bool Existe(Brand Brand)
        {
            if (Brand.BrandId == 0)
            {
                return _db.Brands.Any(s => s.BrandName == Brand.BrandName);
            }
            return _db.Brands.Any(s => s.BrandName == Brand.BrandName &&
                    s.BrandId != Brand.BrandId);
        }

        public void Update(Brand Brand)
        {
            _db.Brands.Update(Brand);
        }
    }
}
