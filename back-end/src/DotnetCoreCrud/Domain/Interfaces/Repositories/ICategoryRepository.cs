using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;

namespace DotnetCoreCrud.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        IEnumerable<Category> GetAll();
        Category GetByGuid(Guid guid);
        void Remove(Guid guid);
        void Update(Category category);
    }
}
