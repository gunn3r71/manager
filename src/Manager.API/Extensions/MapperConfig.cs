using AutoMapper;
using Manager.API.ViewModels;
using Manager.Domain.Entities;
using Manager.Services.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.API.Extensions
{
    public static class MapperConfig
    {
        public static IServiceCollection AddMapperConfg(this IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDto>().ReverseMap();
                c.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
                c.CreateMap<UpdateUserViewModel, UserDto>().ReverseMap();
                c.CreateMap<UserViewModel, UserDto>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            return services;
        }
    }
}