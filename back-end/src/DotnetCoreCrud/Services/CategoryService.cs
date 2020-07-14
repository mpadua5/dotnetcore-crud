using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Repositories;
using DotnetCoreCrud.Domain.Interfaces.Services;
using DotnetCoreCrud.Factories;

namespace DotnetCoreCrud.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ReturnFactory Add(Category category)
        {
            Category item = new Category
            {
                Guid = new Guid(),
                Description = category.Description,
                Products = null
            };
            return _categoryRepository.Add(item).Result;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetByGuid(Guid guid)
        {
            return _categoryRepository.GetByGuid(guid);
        }

        public ReturnFactory Remove(Guid guid)
        {
            return _categoryRepository.Remove(guid).Result;
        }

        public ReturnFactory Update(Category category)
        {
            return _categoryRepository.Update(category).Result;
        }
    }
}
