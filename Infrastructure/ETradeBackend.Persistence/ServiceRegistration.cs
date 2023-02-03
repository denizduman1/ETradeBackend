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
            serviceCollection.AddDbContext<ETradeBackendDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));
            serviceCollection.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            serviceCollection.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            serviceCollection.AddScoped<IOrderReadRepository, OrderReadRepository>();
            serviceCollection.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            serviceCollection.AddScoped<IProductReadRepository, ProductReadRepository>();
            serviceCollection.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
