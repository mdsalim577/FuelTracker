using Microsoft.EntityFrameworkCore;
using FuelTracker.Domain;

namespace FuelTracker.Infrastructure
{
    public class FuelDbContext : DbContext
    {
        public DbSet<FuelRecord> FuelRecords { get; init; }

        public FuelDbContext(DbContextOptions<FuelDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Configure FuelRecord entity
            modelBuilder.Entity<FuelRecord>().ToTable("FuelRecords");
            modelBuilder.Entity<FuelRecord>().Property(fr => fr.FuelType)
                .IsRequired()
                .HasConversion<string>(); // Convert enum to string in the database
        }
    }
}