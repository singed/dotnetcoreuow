using Microsoft.EntityFrameworkCore;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Mappings
{
    public static class CategoryMappings
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories", "dbo");
            
            modelBuilder.Entity<Category>().HasKey(t => t.Id);

            modelBuilder.Entity<Category>().Property(t => t.Id).HasColumnName("CategoryID");
            modelBuilder.Entity<Category>().Property(t => t.CategoryName);

            modelBuilder.Entity<Category>().Property(t => t.Description);
            modelBuilder.Entity<Category>().Property(t => t.Image).HasColumnName("Picture");
        }
    }
}