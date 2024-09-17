using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Datos.Interfaces
{
    public interface IRepositorioGenre : IRepositorioGenerico<Genre>
    {
        void Update(Genre Genre);
        bool Existe(Genre Genre);
        bool EstaRelacionado(int id);
    
    }
}
