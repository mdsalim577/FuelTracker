using FuelTracker.Domain;
using FuelTracker.Infrastructure;

namespace FuelTracker.Application
{

    public class FuelService : IFuelService
    {
        private readonly FuelRepository _fuelRepository;

        public FuelService(FuelRepository fuelRepository)
        {
            ArgumentNullException.ThrowIfNull(fuelRepository);
            
            _fuelRepository = fuelRepository;
        }

        public void AddFuelRecord(FuelRecord record)
        {
            // Additional logic/validation if needed
            _fuelRepository.AddFuelRecord(record);
        }

        public IEnumerable<FuelRecord> GetFuelHistory(string vehicleNumber)
        {
            // Additional logic if needed
            return _fuelRepository.GetFuelHistory(vehicleNumber);
        }

        public void UpdateFuelRecord(FuelRecord record)
        {
            // Additional logic/validation if needed
            _fuelRepository.UpdateFuelRecord(record);
        }

        public void DeleteFuelRecord(int recordId)
        {
            // Additional logic/validation if needed
            _fuelRepository.DeleteFuelRecord(recordId);
        }

        // Implement other methods as needed for your application
    }
}
