using Api_intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_intro.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<GroupStudent> GroupStudent { get; set; }
        public DbSet<Group> Groups { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

      
    }
}
