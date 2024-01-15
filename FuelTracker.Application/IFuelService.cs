using FuelTracker.Domain;

namespace FuelTracker.Application;

public interface IFuelService
{
    void AddFuelRecord(FuelRecord record);

    IEnumerable<FuelRecord> GetFuelHistory(string vehicleNumber);
        
    void UpdateFuelRecord(FuelRecord record);
        
    void DeleteFuelRecord(int recordId);
        
    List<FuelRecord> GetAllFuelRecords();
}