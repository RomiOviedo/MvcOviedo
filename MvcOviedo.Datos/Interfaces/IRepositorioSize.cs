using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Interfaces
{
    public interface IRepositorioSize : IRepositorioGenerico<Size>
    {
        void Update(Size Size);
        bool Existe(Size Size);
        bool EstaRelacionado(int id);
    }
}
