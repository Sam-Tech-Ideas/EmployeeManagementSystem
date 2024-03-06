using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models.Entities;

 namespace EmployeeManagementSystem.Data
 {
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set;}

    }
 }