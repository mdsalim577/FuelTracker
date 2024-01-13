using System.Collections.Generic;
using FuelTracker.Domain;

namespace FuelTracker.Application
{
    public interface IFuelService
    {
        void AddFuelRecord(FuelRecord record);
        List<FuelRecord> GetFuelHistory(string vehicleNumber);
        void UpdateFuelRecord(FuelRecord record);
        void DeleteFuelRecord(int recordId);
    }
}