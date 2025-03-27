using Infrastructure_Layer.Data;
using Infrastructure_Layer.Repository;
using MahalShop.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure_Layer
{
    public static class InfrastructureRegisteration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenricRepository<>), typeof(GenricRepository<>));
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // apply DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                              options.UseSqlServer(configuration.GetConnectionString("DefaulteConnection")));

            return services;
        }
    }
}
