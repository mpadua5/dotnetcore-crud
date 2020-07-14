using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreCrud.Data.Contexts;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using DotnetCoreCrud.Factories;
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

        public async Task<ReturnFactory> Add(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Added;
                _context.Set<Product>().Add(product);
                await _context.SaveChangesAsync();
                Console.WriteLine("[SUCCESS] - Product successfully inserted");
                return new ReturnFactory
                {
                    Code = 1,
                    Message = "Product successfully inserted"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Product insert error - {0}", e.ToString());
                return new ReturnFactory
                {
                    Code = 11,
                    Message = "It was not possible to insert the product, check the data provided."
                };
            }            
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetByGuid(Guid guid)
        {
            return _context.Set<Product>().Find(guid);
        }

        public async Task<ReturnFactory> Remove(Guid guid)
        {
            try
            {
                var product = GetByGuid(guid);

                _context.Entry(product).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                Console.WriteLine("[SUCCESS] - Product successfully removed");
                return new ReturnFactory
                {
                    Code = 1,
                    Message = "Product successfully removed."
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Product removal error - {0}", e.ToString());
                return new ReturnFactory
                {
                    Code = 13,
                    Message = "It was not possible to remove the product, check the data provided."
                };
            }            
        }

        public async Task<ReturnFactory> Update(Product product)
        {
            try
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
                await _context.SaveChangesAsync();
                Console.WriteLine("[SUCCESS] - Product updated successfully");
                return new ReturnFactory
                {
                    Code = 1,
                    Message = "Product updated successfully"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Product update error - {0}", e.ToString());
                return new ReturnFactory
                {
                    Code = 12,
                    Message = "It was not possible to update the product, check the data provided."
                };
            }
        }
    }
}
