using MvcOviedo.Datos.Interfaces;
using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Repositorios
{
    public class RepositorioSize : RepositorioGenerico<Size>, IRepositorioSize
    {
        private readonly MvcOviedoDbContext _db;
        public RepositorioSize(MvcOviedoDbContext? db) : base(db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool EstaRelacionado(int id)
        {
            return false;
            //return _db.Shoes.Any(p => p.SizeId == id);
        }

        public bool Existe(Size Size)
        {
            if (Size.SizeId == 0)
            {
                return _db.Sizes.Any(s => s.SizeNumber == Size.SizeNumber);
            }
            return _db.Sizes.Any(s => s.SizeNumber == Size.SizeNumber &&
                    s.SizeId != Size.SizeId);
        }

        public void Update(Size Size)
        {
            _db.Sizes.Update(Size);
        }
    }
}

