﻿using Infrastructure_Layer.Data;
using Infrastructure_Layer.Repository;
using Infrastructure_Layer.Service;
using MahalShop.Core.Interface;
using MahalShop.Core.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

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

            services.AddSingleton<IImageMangementService, ImageMangementService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            // apply DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                              options.UseSqlServer(configuration.GetConnectionString("DefaulteConnection")
                              /*b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)*/));

            return services;
        }
    }
}
