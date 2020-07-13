using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;

namespace DotnetCoreCrud.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetByGuid(Guid guid);
        void Remove(Guid guid);
        void Update(Product product);
    }
}
