﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOviedo.Entidades
{
    public class Sport
    {
        public int SportId { get; set; }
        public string SportName { get; set; } = null!;
        public bool Active { get; set; } = true;
        //public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

    }
}
