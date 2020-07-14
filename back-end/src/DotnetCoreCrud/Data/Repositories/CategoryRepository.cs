using System;
using System.Collections.Generic;
using System.Linq;
using DotnetCoreCrud.Data.Contexts;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
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

        public async void Add(Category category)
        {
            _context.Set<Category>().Add(category);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Set<Category>().ToList();
        }

        public Category GetByGuid(Guid guid)
        {
            return _context.Set<Category>().Find(guid);
        }

        public async void Remove(Guid guid)
        {
            var category = GetByGuid(guid);

            _context.Set<Category>().Remove(category);
            await _context.SaveChangesAsync();
        }

        public async void Update(Category category)
        {
            var item = GetByGuid(category.Guid);
            item.Description = category.Description;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
