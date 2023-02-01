using ETradeBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> 
        where T : BaseEntity 
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> Remove(T entity);
        Task<bool> RemoveRange(List<T> entities);
        Task<bool> Remove(string id);
        Task<int> SaveAsync();
    }
}
