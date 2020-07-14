using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Factories;

namespace DotnetCoreCrud.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<ReturnFactory> Add(Category category);
        IEnumerable<Category> GetAll();
        Category GetByGuid(Guid guid);
        Task<ReturnFactory> Remove(Guid guid);
        Task<ReturnFactory> Update(Category category);
    }
}
