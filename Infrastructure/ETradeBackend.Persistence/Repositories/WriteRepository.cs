using ETradeBackend.Application.Repositories;
using ETradeBackend.Domain.Entities.Common;
using ETradeBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETradeBackendDbContext _context;

        public WriteRepository(ETradeBackendDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return EntityState.Added == entityEntry.State;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public async Task<bool> Remove(T entity)
        {
            EntityEntry<T> entityEntry = await Task.Run(() => Table.Remove(entity)); 
            return EntityState.Deleted== entityEntry.State;
        }

        public async Task<bool> Remove(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(t=>t.Id == Guid.Parse(id));
            return await Remove(entity);
        }

        public async Task<bool> RemoveRange(List<T> entities)
        {
            await Task.Run(() => Table.RemoveRange(entities));    
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Task.Run(() => Table.Update(entity));
            return EntityState.Modified == entityEntry.State;
        }
    }
}
