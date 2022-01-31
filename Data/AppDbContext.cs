using Microsoft.EntityFrameworkCore;
using graphqldotnettutorial.Models;

namespace graphqldotnettutorial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        // DbSet is table , pluralise the name
        public DbSet<Platform> Platforms { get; set; }
    }
}