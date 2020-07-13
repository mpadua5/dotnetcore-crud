using System;
using System.Collections.Generic;
using System.Linq;
using DotnetCoreCrud.Data.Contexts;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreCrud.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetByGuid(Guid guid)
        {
            return _context.Set<Product>().Find(guid);
        }

        public void Remove(Guid guid)
        {
            var product = GetByGuid(guid);

            //_context.Set<Product>().Remove(product);
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var local = _context.Set<Category>().Local.FirstOrDefault(category => category.Guid.Equals(product.Category.Guid));
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            var item = GetByGuid(product.Guid);
            item.Description = product.Description;
            item.Amount = product.Amount;
            item.UnitValue = product.UnitValue;
            item.Unity = product.Unity;
            item.Category = new Category
            {
                Guid = product.Category.Guid,
                Description = product.Category.Description
            };

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
