using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infrastructure.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Shared.Exceptions;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            var exists = await Exists(x => x.Email == userDto.Email);

            if (exists) throw new DomainException("Email already exist.");

            var createdUser = await _repository.CreateAsync(_mapper.Map<User>(userDto));

            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            var exists = await Exists(x => x.Id == userDto.Id);

            if (!exists) throw new DomainException("User to be updated doesn't exist.");

            var updatedUser = await _repository.UpdateAsync(_mapper.Map<User>(userDto));

            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task Remove(Guid userId)
        {
            var exists = await Exists(x => x.Id == userId);

            if (!exists) throw new DomainException("User to be removed doesn't exist.");

            await _repository.RemoveAsync(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _repository.GetAllAsync());

            return users;
        }

        public async Task<UserDto> FindById(Guid userId)
        {
            var user = _mapper.Map<UserDto>(await _repository.FindByIdAsync(userId));

            return user;
        }

        public async Task<UserDto> FindByEmail(string email)
        {
            var user = _mapper.Map<UserDto>(await _repository.FindByEmailAsync(email));

            return user;
        }

        public async Task<IEnumerable<UserDto>> SearchByName(string name)
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _repository.SearchByName(name));

            return users;
        }

        public async Task<IEnumerable<UserDto>> SearchByEmail(string email)
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _repository.SearchByEmail(email));

            return users;
        }

        private async Task<bool> Exists(Func<User,bool> expression)
        {
            return await _repository.Exists(expression);
        }
    }
}