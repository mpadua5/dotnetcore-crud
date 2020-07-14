using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Factories;

namespace DotnetCoreCrud.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ReturnFactory> Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetByGuid(Guid guid);
        Task<ReturnFactory> Remove(Guid guid);
        Task<ReturnFactory> Update(Product product);
    }
}
