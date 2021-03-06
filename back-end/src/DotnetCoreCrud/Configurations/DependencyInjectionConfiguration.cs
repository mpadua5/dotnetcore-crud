﻿using System;
using DotnetCoreCrud.Data.Contexts;
using DotnetCoreCrud.Data.Repositories;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using DotnetCoreCrud.Domain.Interfaces.Services;
using DotnetCoreCrud.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCoreCrud.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<DefaultContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>(); 
            services.AddScoped<IProductService, ProductService>(); 
        }
    }
}
