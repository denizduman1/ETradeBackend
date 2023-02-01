using ETradeBackend.Application.Repositories;
using ETradeBackend.Persistence.Contexts;
using ETradeBackend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ETradeBackendDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
            serviceCollection.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            serviceCollection.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            serviceCollection.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            serviceCollection.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            serviceCollection.AddSingleton<IProductReadRepository, ProductReadRepository>();
            serviceCollection.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
