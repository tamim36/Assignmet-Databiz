using System;
using Microsoft.EntityFrameworkCore;

namespace WebService.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    // // // If Migrations is not successful then follow this (N.B. This will delete database) ->
    // 
    // Remove all .cs files from migrations folder 
    // From Solution Directory 
    // dotnet ef database drop -f -v
    // dotnet ef migrations add InitialMigration
    // dotnet ef database update
}
