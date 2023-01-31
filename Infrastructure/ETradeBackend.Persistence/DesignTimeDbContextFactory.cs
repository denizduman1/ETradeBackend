using ETradeBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETradeBackendDbContext>
    {
        public ETradeBackendDbContext CreateDbContext(string[] args)
        {            
            DbContextOptionsBuilder<ETradeBackendDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new ETradeBackendDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
