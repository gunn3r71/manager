using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        protected readonly ManagerContext _context;
        private readonly DbSet<T> _entity;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _entity.Add(entity);
            await Save();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();

            return entity;
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var entity = await FindByIdAsync(id);

            if (entity is not null)
            {
                _entity.Remove(entity);
                await Save();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity
                            .AsNoTracking()
                            .ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(Guid id)
        {
            return await _entity
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Exists(Func<T, bool> expression)
        {
            var result = await _entity.ToListAsync();

            return result.Any(expression);
        }

        protected async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}