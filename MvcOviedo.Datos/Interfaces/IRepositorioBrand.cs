using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Interfaces
{
    public interface IRepositorioBrand: IRepositorioGenerico<Brand>
    {
        void Update(Brand Brand);
        bool Existe(Brand Brand);
        bool EstaRelacionado(int id);
    }
}
