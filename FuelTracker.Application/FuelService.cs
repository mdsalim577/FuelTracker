﻿using FuelTracker.Domain;
using FuelTracker.Infrastructure;

namespace FuelTracker.Application;

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
        _fuelRepository.AddFuelRecord(record);
    }

    public IEnumerable<FuelRecord> GetFuelHistory(string vehicleNumber, int page = 1, int pageSize = 10)
    {
        return _fuelRepository.GetFuelHistory(vehicleNumber)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }

    public void UpdateFuelRecord(FuelRecord record)
    {
        _fuelRepository.UpdateFuelRecord(record);
    }

    public void DeleteFuelRecord(int recordId)
    {
        _fuelRepository.DeleteFuelRecord(recordId);
    }

    public IEnumerable<FuelRecord> GetAllFuelRecords(int page = 1, int pageSize = 10)
    {
        return _fuelRepository.GetAllFuelRecords()
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}