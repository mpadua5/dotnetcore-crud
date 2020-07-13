using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using DotnetCoreCrud.Domain.Interfaces.Services;

namespace DotnetCoreCrud.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            Category item = new Category
            {
                Guid = new Guid(),
                Description = category.Description,
                Products = null
            };
            _categoryRepository.Add(item);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetByGuid(Guid guid)
        {
            return _categoryRepository.GetByGuid(guid);
        }

        public void Remove(Guid guid)
        {
            _categoryRepository.Remove(guid);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
