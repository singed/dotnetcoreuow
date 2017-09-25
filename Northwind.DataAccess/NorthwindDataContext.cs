using Microsoft.EntityFrameworkCore;
using Northwind.DataAccess.Mappings;
using Repository.Pattern.EfCore;

namespace Northwind.DataAccess
{
    public class NorthwindDataContext : DataContext, INorthwindDataContext
    {
        public NorthwindDataContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProductMappings.Map(modelBuilder);
            CategoryMappings.Map(modelBuilder);
            SupplierMappings.Map(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}