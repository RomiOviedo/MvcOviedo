using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Entidades
{
    public class Size
    {
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; } = 0!;

        //public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

    }
}
