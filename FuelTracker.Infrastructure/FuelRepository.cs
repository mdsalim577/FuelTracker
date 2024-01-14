using FuelTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Infrastructure
{
    public class FuelRepository
    {
        private readonly FuelDbContext _dbContext;

        public FuelRepository(FuelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddFuelRecord(FuelRecord record)
        {
            _dbContext.FuelRecords.Add(record);
            _dbContext.SaveChanges();
        }

        public IEnumerable<FuelRecord> GetFuelHistory(string vehicleNumber)
        {
            return _dbContext.FuelRecords
                .Where(r => r.VehicleNumber == vehicleNumber);
        }

        public void UpdateFuelRecord(FuelRecord record)
        {
            _dbContext.Entry(record).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteFuelRecord(int recordId)
        {
            var record = _dbContext.FuelRecords.Find(recordId);
            if (record != null)
            {
                _dbContext.FuelRecords.Remove(record);
                _dbContext.SaveChanges();
            }
        }
        
        public List<FuelRecord> GetAllFuelRecords()
        {
            // Assuming you have a DbSet property for FuelRecords in FuelDbContext
            return _dbContext.FuelRecords.ToList();
        }
  }
}