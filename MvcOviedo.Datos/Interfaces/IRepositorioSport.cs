using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Interfaces
{
    public interface IRepositorioSport : IRepositorioGenerico<Sport>
    {
        void Update(Sport Sport);
        bool Existe(Sport Sport);
        bool EstaRelacionado(int id);

    }
}
