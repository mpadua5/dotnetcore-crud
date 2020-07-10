using System;
using DotnetCoreCrud.Configurations;
using DotnetCoreCrud.Data.Configurations;
using DotnetCoreCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreCrud.Data.Contexts
{
    public class DefaultContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        public DefaultContext()
        {
            Database.SetCommandTimeout(120);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(DatabaseConfiguration.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }    
}
