using FuelTracker.Domain;

namespace FuelTracker.Application;

public interface IFuelService
{
    void AddFuelRecord(FuelRecord record);

    IEnumerable<FuelRecord> GetFuelHistory(string vehicleNumber, int page, int pageSize);
        
    void UpdateFuelRecord(FuelRecord record);
        
    void DeleteFuelRecord(int recordId);
        
    IEnumerable<FuelRecord> GetAllFuelRecords(int page, int pageSize);
}