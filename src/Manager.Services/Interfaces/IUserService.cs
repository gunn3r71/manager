using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(CreateUserDto userDto);
        Task<UserDto> Update(UpdateUserDTO userDto);

        Task Remove(Guid userId);
        Task<UserDto> FindById(Guid userId);
        Task<IEnumerable<UserDto>> GetAll();
        Task<IEnumerable<UserDto>> SearchByName(string name);
        Task<IEnumerable<UserDto>> SearchByEmail(string email);
        Task<UserDto> FindByEmail(string email);
    }
}