using ETradeBackend.Application.Repositories;
using ETradeBackend.Domain.Entities.Common;
using ETradeBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETradeBackendDbContext _context;

        public ReadRepository(ETradeBackendDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filterMethod) => await Table.FirstOrDefaultAsync(filterMethod);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filterMethod) => Table.Where(filterMethod);
    }
}
