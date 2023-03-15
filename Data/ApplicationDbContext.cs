using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Data.Entity;

namespace PayRoll.Data
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {
        // Check if Database exists, else create
        Database.EnsureCreated();
    }
   public Microsoft.EntityFrameworkCore.DbSet<Models.Employee> Employees { get; set; }
}
}
