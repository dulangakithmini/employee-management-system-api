using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOne(d => d.Department);
        }
    }
}