using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;

namespace Manager.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> FindByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> Exists(Func<T, bool> expression);
    }
}