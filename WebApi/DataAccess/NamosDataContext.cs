using Microsoft.EntityFrameworkCore;
using Repository.Pattern.EfCore;

namespace WebApi.DataAccess
{
    public partial class NamosDataContext : DataContext, INamosDataContext
    {
        public NamosDataContext(DbContextOptions<DbContext> options) : base(options)
        {
           
        }
        public DbSet<Employee> BarcodeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees", "dbo");

            modelBuilder.Entity<Employee>().HasKey(t => t.Id);

            modelBuilder.Entity<Employee>().Property(t => t.Id).HasColumnName("employee_id");
            modelBuilder.Entity<Employee>().Property(t => t.FirstName).HasColumnName("first_name");

            modelBuilder.Entity<Employee>().Property(t => t.LastName).HasColumnName("last_name")
                .IsRequired();

            modelBuilder.Entity<Employee>().Property(t => t.Salary).HasColumnName("salary");

            base.OnModelCreating(modelBuilder); 
        }
        
        
    }
}