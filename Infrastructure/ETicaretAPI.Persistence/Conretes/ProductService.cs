using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Conretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new()
        {
            new(){ Id=Guid.NewGuid(), Name="Product 1", Stock=10, Price=50},
            new(){ Id=Guid.NewGuid(), Name="Product 2", Stock=20, Price=60},
            new(){ Id=Guid.NewGuid(), Name="Product 3", Stock=30, Price=70},
            new(){ Id=Guid.NewGuid(), Name="Product 4", Stock=40, Price=80},
            new(){ Id=Guid.NewGuid(), Name="Product 5", Stock=50, Price=90}
        };
    }
}
