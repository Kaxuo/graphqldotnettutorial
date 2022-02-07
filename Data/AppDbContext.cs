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
        public DbSet<Command> Commands { get; set; }

        // Withone platform! = nullable
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);
            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);
        }
    }
}