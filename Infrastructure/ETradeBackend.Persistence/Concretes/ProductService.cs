using ETradeBackend.Application.Abstractions;
using ETradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts() => new()
        {
            new()
            {
                CreatedDate= DateTime.Now,
                Id= Guid.NewGuid(),
                Name = "Bilgisayar",
                Price = 40000,
                Stock = 3
            },
            new()
            {
                CreatedDate= DateTime.Now,
                Id= Guid.NewGuid(),
                Name = "Bilgisayar",
                Price = 20000,
                Stock = 4
            },
            new()
            {
                CreatedDate= DateTime.Now,
                Id= Guid.NewGuid(),
                Name = "Bilgisayar",
                Price = 30000,
                Stock = 5
            },
            new()
            {
                CreatedDate= DateTime.Now,
                Id= Guid.NewGuid(),
                Name = "Bilgisayar",
                Price = 10000,
                Stock = 2
            }
        };
    }
}
