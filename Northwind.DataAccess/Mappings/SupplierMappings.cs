using Microsoft.EntityFrameworkCore;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Mappings
{
    public static class SupplierMappings
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Suppliers", "dbo");
            
            modelBuilder.Entity<Supplier>().HasKey(t => t.Id);

            modelBuilder.Entity<Supplier>().Property(t => t.Id).HasColumnName("SupplierID");
            modelBuilder.Entity<Supplier>().Property(t => t.Name).HasColumnName("CompanyName");
            modelBuilder.Entity<Supplier>().Property(t => t.ContactName);
            modelBuilder.Entity<Supplier>().Property(t => t.ContactTitle);
            modelBuilder.Entity<Supplier>().Property(t => t.Address);
            modelBuilder.Entity<Supplier>().Property(t => t.City);
            modelBuilder.Entity<Supplier>().Property(t => t.Region);
            modelBuilder.Entity<Supplier>().Property(t => t.PostalCode);
            modelBuilder.Entity<Supplier>().Property(t => t.Country);
            modelBuilder.Entity<Supplier>().Property(t => t.Phone);
            modelBuilder.Entity<Supplier>().Property(t => t.Fax);
            modelBuilder.Entity<Supplier>().Property(t => t.HomePage);
        }
    }
}