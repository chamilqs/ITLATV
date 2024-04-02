using ITLATV.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITLATV.Core.Application.Interfaces.Services;

namespace ITLATV.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {   
            #region Servicios
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<ISerieService, SerieService>();
            services.AddTransient<IProductoraService, ProductoraService>();
            #endregion
        }
    }
}
