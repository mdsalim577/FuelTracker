using FuelTracker.Application;
using FuelTracker.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FuelTracker.WebApi.Controllers;

[Route("api/v1/vehicle")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;
    private readonly ILogger<FuelController> _logger;

    public FuelController(
        IFuelService fuelService
        , ILogger<FuelController> logger)
    {
        ArgumentNullException.ThrowIfNull(fuelService);
        ArgumentNullException.ThrowIfNull(logger);
        
        _fuelService = fuelService;
        _logger = logger;
    }

    [HttpPost("{vehicleNumber}")]
    public IActionResult AddFuelRecord([FromBody] FuelRecord record, string vehicleNumber)
    {
        _logger.LogDebug("Hitting api to initiate adding fuel record");
        
        if (record.Date == default || record.Date == DateTime.MinValue || record.Date == DateTime.MaxValue)
        {
            record.Date = DateTime.UtcNow;
        }

        record.VehicleNumber = vehicleNumber;
        _fuelService.AddFuelRecord(record);
        
        return Ok("Record added successfully");
    }

    [HttpGet("{vehicleNumber}/history")]
    public IActionResult GetFuelHistory(string vehicleNumber)
    {
        var history = _fuelService.GetFuelHistory(vehicleNumber);
        return Ok(history);
    }

    [HttpPut("{vehicleNumber}/correct")]
    public IActionResult UpdateFuelRecord([FromBody] FuelRecord record, string vehicleNumber)
    {
        record.VehicleNumber = vehicleNumber;
        _fuelService.UpdateFuelRecord(record);
        return Ok("Record updated successfully");
    }

    [HttpDelete("{recordId}")]
    public IActionResult DeleteFuelRecord(int recordId)
    {
        _fuelService.DeleteFuelRecord(recordId);
        return Ok("Record deleted successfully");
    }

    [HttpGet("all")]
    public IActionResult GetAllFuelRecords()
    {
        var allRecords = _fuelService.GetAllFuelRecords();
        return Ok(allRecords);
    }
}