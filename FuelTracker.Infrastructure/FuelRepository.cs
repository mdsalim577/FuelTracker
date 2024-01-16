using FuelTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Infrastructure;

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

    public IEnumerable<FuelRecord> GetFuelHistory(string vehicleNumber, int page = 1, int pageSize = 10)
    {
        return _dbContext.FuelRecords
            .Where(record => record.VehicleNumber == vehicleNumber)
            .OrderByDescending(record => record.Date)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
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
        
    public IEnumerable<FuelRecord> GetAllFuelRecords(int page = 1, int pageSize = 10)
    {
        return _dbContext.FuelRecords
            .OrderByDescending(record => record.Date)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}