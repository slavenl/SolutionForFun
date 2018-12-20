using Microsoft.EntityFrameworkCore;
using WebApiService.Contracts.Models;

namespace WebApiService.Infrastructure
{
    public partial class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext() : base() { }


        public EmployeesDBContext(DbContextOptions<EmployeesDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeData> EmployeesData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=mySqLite.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, FirstName = "Mangesh", LastName = "G" },
                new Employee() { EmployeeId = 2, FirstName = "Ramnath", LastName = "Bodke" },
                new Employee() { EmployeeId = 3, FirstName = "Suraj", LastName = "G" },
                new Employee() { EmployeeId = 4, FirstName = "Jaffar", LastName = "K" }
                );

            modelBuilder.Entity<EmployeeData>().HasData(
                new EmployeeData() { EmployeeId = 1, EmployeeDataId = 1, Email = "Mangesh.g@outlook.com", Gender = "1", Phone = "123" },
                new EmployeeData() { EmployeeId = 2, EmployeeDataId = 2, Email = "Ramnagh.g@outlook.com", Gender = "1", Phone = "223" },
                new EmployeeData() { EmployeeId = 3, EmployeeDataId = 3, Email = "suraj.g@gmail.com", Gender = "1", Phone = "323" },
                new EmployeeData() { EmployeeId = 4, EmployeeDataId = 4, Email = "Jaffar.g@outlook.com", Gender = "1", Phone = "423" }
                );
        }


    }
}


//dotnet ef migrations add InitialCreate
//dotnet ef database update