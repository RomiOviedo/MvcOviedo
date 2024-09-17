using Microsoft.EntityFrameworkCore;
using MvcOviedo.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Size = MvcOviedo.Entidades.Size;

namespace MvcOviedo.Datos
{
    public class MvcOviedoDbContext : DbContext
    {
        public MvcOviedoDbContext(DbContextOptions<MvcOviedoDbContext>
            options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Colour> Colours { get; set; }
        //public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        //public DbSet<ShoeSize> ShoesSizes { get; set; }
    }
}
