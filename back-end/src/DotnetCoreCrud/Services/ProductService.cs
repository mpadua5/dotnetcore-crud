using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using DotnetCoreCrud.Domain.Interfaces.Services;
using DotnetCoreCrud.Factories;

namespace DotnetCoreCrud.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ReturnFactory Add(Product product)
        {
            return _productRepository.Add(product).Result;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByGuid(Guid guid)
        {
            return _productRepository.GetByGuid(guid);
        }

        public ReturnFactory Remove(Guid guid)
        {
            return _productRepository.Remove(guid).Result;
        }

        public ReturnFactory Update(Product product)
        {
            return _productRepository.Update(product).Result;
        }
    }
}
