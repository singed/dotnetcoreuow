using Microsoft.EntityFrameworkCore;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Mappings
{
    public static class ProductMappings
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", "dbo");
            
            modelBuilder.Entity<Product>().HasKey(t => t.Id);

            modelBuilder.Entity<Product>().Property(t => t.Id).HasColumnName("ProductID");
            modelBuilder.Entity<Product>().Property(t => t.Name).HasColumnName("ProductName");

            modelBuilder.Entity<Product>().Property(t => t.SupplierId);
            modelBuilder.Entity<Product>().Property(t => t.CategoryId);
            modelBuilder.Entity<Product>().Property(t => t.QuantityPerUnit);
            modelBuilder.Entity<Product>().Property(t => t.UnitPrice);
            modelBuilder.Entity<Product>().Property(t => t.UnitsInStock);
            modelBuilder.Entity<Product>().Property(t => t.UnitsOnOrder);
            modelBuilder.Entity<Product>().Property(t => t.ReorderLevel);
            modelBuilder.Entity<Product>().Property(t => t.Discontinued);

            modelBuilder.Entity<Product>().HasOne(t => t.Category).WithMany(x => x.Products);
        }
    }
}