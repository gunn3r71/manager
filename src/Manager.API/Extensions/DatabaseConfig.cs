using System;
using Manager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.API.Extensions
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ManagerContext>(x =>
            {
                x.UseSqlServer(connectionString, c =>
                {
                    c.EnableRetryOnFailure(3, new TimeSpan(0, 0, 0, 30), null);
                    c.CommandTimeout(30);
                    c.MigrationsHistoryTable("Migrations");
                    c.MigrationsAssembly(typeof(ManagerContext).Assembly.FullName);
                });
            });

            return services;
        }
    }
}
