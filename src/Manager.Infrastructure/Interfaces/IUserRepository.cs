using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;

namespace Manager.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task<IEnumerable<User>> SearchByEmail(string email);
        Task<IEnumerable<User>> SearchByName(string name);
    }
}