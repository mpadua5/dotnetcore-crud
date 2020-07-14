using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Factories;

namespace DotnetCoreCrud.Domain.Interfaces.Services
{
    public interface IProductService
    {
        ReturnFactory Add(Product product);
        Product GetByGuid(Guid guid);
        IEnumerable<Product> GetAll();
        ReturnFactory Update(Product product);
        ReturnFactory Remove(Guid guid);
    }
}
