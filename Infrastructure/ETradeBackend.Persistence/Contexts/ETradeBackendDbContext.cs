using ETradeBackend.Domain.Entities;
using ETradeBackend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.Contexts
{
    public class ETradeBackendDbContext : DbContext
    {
        public ETradeBackendDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var baseEntities = ChangeTracker.Entries<BaseEntity>();

            foreach (var baseEntity in baseEntities)
            {
                _ = baseEntity.State switch {
                    EntityState.Added => baseEntity.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => baseEntity.Entity.ModifiedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
