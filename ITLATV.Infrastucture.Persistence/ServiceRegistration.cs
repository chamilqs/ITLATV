using ITLATV.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITLATV.Core.Application.Interfaces.Repositories;
using ITLATV.Infrastructure.Persistence.Contexts;
using ITLATV.Infrastucture.Persistence.Repositories;

namespace ITLATV.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m=> m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<ISerieRepository, SerieRepository>();
            services.AddTransient<IProductoraRepository, ProductoraRepository>();
            #endregion
        }
    }
}
