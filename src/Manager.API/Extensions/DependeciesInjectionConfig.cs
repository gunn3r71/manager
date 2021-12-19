using System;
using AutoMapper;
using Manager.API.Security;
using Manager.Infrastructure;
using Manager.Infrastructure.Interfaces;
using Manager.Infrastructure.Repositories;
using Manager.Services.Interfaces;
using Manager.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.API.Extensions
{
    public static class DependeciesInjectionConfig 
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //database
            services.AddDbConfiguration(configuration);

            //mapper
            services.AddMapperConfg();

            //services
            services.AddScoped<IUserService, UserService>();

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //Security
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }
    }
}