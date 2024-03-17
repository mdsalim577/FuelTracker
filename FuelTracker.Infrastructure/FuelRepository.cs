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

    public void UpdateFuelRecord(FuelRecord updatedRecord)
    {
        var existingRecord = _dbContext.FuelRecords.FirstOrDefault(fr => fr.Id == updatedRecord.Id);

        if (existingRecord != null)
        {
            // Map only the properties you want to allow updating. This example updates all, but you can exclude some if necessary.
            _dbContext.Entry(existingRecord).CurrentValues.SetValues(updatedRecord);

            // For properties not included in SetValues, you can manually update them if needed
            // Example: existingRecord.SomeProperty = updatedRecord.SomeProperty;

            _dbContext.SaveChanges();
        }
        else
        {
            // Handle the case where the record does not exist. You could throw an exception or handle it according to your application needs.
            throw new ArgumentException("Record not found", nameof(updatedRecord.Id));
        }
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