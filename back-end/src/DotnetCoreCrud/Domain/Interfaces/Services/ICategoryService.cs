using System;
using System.Collections.Generic;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Factories;

namespace DotnetCoreCrud.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        ReturnFactory Add(Category category);
        Category GetByGuid(Guid guid);
        IEnumerable<Category> GetAll();
        ReturnFactory Update(Category category);
        ReturnFactory Remove(Guid guid);
    }
}
