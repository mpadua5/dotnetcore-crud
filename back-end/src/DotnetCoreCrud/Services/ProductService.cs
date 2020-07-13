using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using DotnetCoreCrud.Domain.Interfaces.Services;

namespace DotnetCoreCrud.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByGuid(Guid guid)
        {
            return _productRepository.GetByGuid(guid);
        }

        public void Remove(Guid guid)
        {
            _productRepository.Remove(guid);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
