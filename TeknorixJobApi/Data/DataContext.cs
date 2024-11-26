using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Models.Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
