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
            // Define the table and its properties
            modelBuilder.Entity<FuelRecord>(entity =>
            {
                entity.ToTable("FuelRecords");

                entity.HasKey(e => e.Id); // Primary Key

                entity.Property(e => e.VehicleNumber)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .IsRequired();

                entity.Property(e => e.FuelAmount)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.Property(e => e.DriverName);

                entity.Property(e => e.FuelType)
                    .IsRequired();
            });
        }
    }
}