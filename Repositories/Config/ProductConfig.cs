using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product { ProductId = 1, CategoryId=2, ImageUrl="/img/1.jpeg", ProductName = "Computer", Price = 1800},
                new Product { ProductId = 2, CategoryId=2, ImageUrl="/img/2.jpeg", ProductName = "Mouse", Price = 250},
                new Product { ProductId = 3, CategoryId=2, ImageUrl="/img/3.jpeg", ProductName = "Keyboard", Price = 700},
                new Product { ProductId = 4, CategoryId=2, ImageUrl="/img/4.jpeg", ProductName = "Monitor", Price = 1500},
                new Product { ProductId = 5, CategoryId=2, ImageUrl="/img/5.jpeg", ProductName = "Headphones", Price = 1000},
                new Product { ProductId = 6, CategoryId=1, ImageUrl="/img/6.jpeg", ProductName = "History", Price = 25},
                new Product { ProductId = 7, CategoryId=1, ImageUrl="/img/7.jpeg", ProductName = "Hamlet", Price = 45}
            );
        }
    }
}