using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ManagerContext context) : base(context)
        {
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users
                                    .AsNoTracking()
                                    .Where(x => x.Email == email)
                                    .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> SearchByEmail(string email)
        {
            return await _context.Users
                                    .AsNoTracking()
                                    .Where(x => x.Email.Contains(email))
                                    .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchByName(string name)
        {
            return await _context.Users
                                    .AsNoTracking()
                                    .Where(x => x.Name.Contains(name))
                                    .ToListAsync();
        }
    }
}