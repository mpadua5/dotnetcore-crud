using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;

namespace DotnetCoreCrud.Domain.Services
{
    public interface ICategoryService
    {
        void Add(Category category);
        Category GetByGuid(Guid guid);
        IEnumerable<Category> GetAll();
        void Update(Category category);
        void Remove(Guid guid);
    }
}
