using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;

namespace DotnetCoreCrud.Domain.Interfaces.Services
{
    public interface IProductService
    {
        void Add(Product product);
        Product GetByGuid(Guid guid);
        IEnumerable<Product> GetAll();
        void Update(Product product);
        void Remove(Guid guid);
    }
}
