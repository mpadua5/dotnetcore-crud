using System;
using DotnetCoreCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetCoreCrud.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(category => category.Guid);

            builder
                .Property(category => category.Guid)
                .HasColumnName("guid");

            builder
                .Property(category => category.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(128)")
                .IsRequired();

            builder
                .HasMany(category => category.Products)
                .WithOne(product => product.Category);
        }
    }
}
