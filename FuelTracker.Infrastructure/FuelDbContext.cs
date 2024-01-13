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
    }
}