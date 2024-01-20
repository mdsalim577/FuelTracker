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
    
    [HttpGet("all")]
    public IActionResult GetAllFuelRecords([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var allRecords = _fuelService.GetAllFuelRecords(page, pageSize);
        return Ok(allRecords);
    }
    
    [HttpGet("{vehicleNumber}/history")]
    public IActionResult GetFuelHistory(string vehicleNumber, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var history = _fuelService.GetFuelHistory(vehicleNumber, page, pageSize);
        return Ok(history);
    }

    [HttpPost("{vehicleNumber}")]
    public IActionResult AddFuelRecord([FromBody] FuelRecord record, string vehicleNumber)
    {
        _logger.LogDebug("Hitting api to initiate adding fuel record");
        
        if (record.Date == default || record.Date == DateTime.MinValue || record.Date == DateTime.MaxValue)
        {
            record.Date = DateTime.UtcNow;
        }

        record.Id = Guid.NewGuid();
        record.VehicleNumber = vehicleNumber;
        _fuelService.AddFuelRecord(record);
        
        return Ok("Record added successfully");
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
}