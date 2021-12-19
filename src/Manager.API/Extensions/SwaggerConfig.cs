using Microsoft.Extensions.DependencyInjection;

namespace Manager.API.Extensions
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new()
                    {
                        Title = "Manager.API",
                        Version = "v1",
                        Description = "API created to provide an interface for user registration and management",
                        Contact = new()
                        {
                            Name = "Lucas Pereira",
                            Email = "lucas.p.oliveira@outlook.pt",
                            Url = new("https://github.com/gunn3r71/")
                        },
                        License = new()
                        {
                            Name = "MIT",
                            Url = new("https://github.com/gunn3r71/manager/blob/master/license.txt")
                        }
                    });
            });

            return services;
        }
    }
}
