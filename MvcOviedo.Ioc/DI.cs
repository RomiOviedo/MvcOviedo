using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcOviedo.Datos;
using MvcOviedo.Datos.Interfaces;
using MvcOviedo.Datos.Repositorios;
using MvcOviedo.Servicios.Interfaces;
using MvcOviedo.Servicios.Servicios;


namespace MvcOviedo.Ioc
{
    public class DI
    {
        public static void ConfigurarServicios(IServiceCollection servicios,
            IConfiguration configuration)
        {

            servicios.AddScoped<IRepositorioGenre, RepositorioGenre>();
            servicios.AddScoped<IServicioGenre, ServicioGenre>();
            servicios.AddScoped<IRepositorioBrand, RepositorioBrand>();
            servicios.AddScoped<IServicioBrand, ServicioBrand>();
            servicios.AddScoped<IRepositorioColour, RepositorioColour>();
            servicios.AddScoped<IServicioColour, ServicioColour>();
            servicios.AddScoped<IRepositorioSport, RepositorioSport>();
            servicios.AddScoped<IServicioSport, ServicioSport>();
            servicios.AddScoped<IRepositorioSize, RepositorioSize>();
            servicios.AddScoped<IServicioSize, ServicioSize>();
            //servicios.AddScoped<IRepositorioShoe, RepositorioShoe>();
            //servicios.AddScoped<IServicioShoe, ServicioShoe>();

            servicios.AddScoped<IUnitOfWork, UnitOfWork>();

            servicios.AddDbContext<MvcOviedoDbContext>(options =>
            {
                options.UseSqlServer
                (configuration.GetConnectionString("MyConnection"));
            });


        }
    }
}
