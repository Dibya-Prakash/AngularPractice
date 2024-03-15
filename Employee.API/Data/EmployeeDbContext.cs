using Employee.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Data
{
    public class EmployeeDbContext: DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EmployeeDbContext(DbContextOptions options) : base(options) //when we give options to our class it passes on to the base class
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
