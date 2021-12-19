using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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

                c.AddSecurityDefinition("Bearer", new()
                {
                    In = ParameterLocation.Header,
                    Description = "Please, Use Bearer <Token>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}
