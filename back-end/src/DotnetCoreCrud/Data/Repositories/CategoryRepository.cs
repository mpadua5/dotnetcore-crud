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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DefaultContext _context;
        public CategoryRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<ReturnFactory> Add(Category category)
        {
            try
            {
                _context.Set<Category>().Add(category);
                await _context.SaveChangesAsync();
                Console.WriteLine("[SUCCESS] - Category successfully inserted");
                return new ReturnFactory
                {
                    Code = 1,
                    Message = "Category successfully inserted"
                };
            }
            catch(Exception e)
            {
                Console.WriteLine("[ERROR] - Category insertion error - {0}", e.ToString());
                return new ReturnFactory
                {
                    Code = 21,
                    Message = "It was not possible to insert the category, check the data provided."
                };
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Set<Category>().ToList();
        }

        public Category GetByGuid(Guid guid)
        {
            return _context.Set<Category>().Find(guid);
        }

        public async Task<ReturnFactory> Remove(Guid guid)
        {
            try
            {
                var category = GetByGuid(guid);

                _context.Set<Category>().Remove(category);
                await _context.SaveChangesAsync();
                Console.WriteLine("[SUCCESS] - Category successfully removed");
                return new ReturnFactory
                {
                    Code = 1,
                    Message = "Category successfully removed"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Category removal error - {0}", e.ToString());
                return new ReturnFactory
                {
                    Code = 23,
                    Message = "It was not possible to remove the category, check the data provided."
                };
            }
        }

        public async Task<ReturnFactory> Update(Category category)
        {
            try
            {
                var item = GetByGuid(category.Guid);
                item.Description = category.Description;

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                Console.WriteLine("[SUCCESS] - Category updated successfully");
                return new ReturnFactory
                {
                    Code = 1,
                    Message = "Category updated successfully"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Category update error - {0}", e.ToString());
                return new ReturnFactory
                {
                    Code = 22,
                    Message = "It was not possible to update the category, check the data provided."
                };
            }
        }
    }
}
