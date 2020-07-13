using System;
using DotnetCoreCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetCoreCrud.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(product => product.Guid);

            builder
                .Property(product => product.Guid)
                .HasColumnName("guid");

            builder
                .Property(product => product.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(128)")
                .IsRequired();

            builder
                .Property(product => product.Unity)
                .HasColumnName("unity")
                .HasColumnType("char(3)")
                .IsRequired();

            builder
                .Property(product => product.UnitValue)
                .HasColumnName("unit_value")
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            builder
                .Property(product => product.Amount)
                .HasColumnName("amount")
                .HasColumnType("float(6,3)")
                .IsRequired();

            builder
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey("product_category")
                .IsRequired();
        }
    }
}
