using FuelTracker.Application;
using FuelTracker.Domain;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/vehicle")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;

    public FuelController(IFuelService fuelService)
    {
        ArgumentNullException.ThrowIfNull(fuelService);
        
        _fuelService = fuelService;
    }

    [HttpPost("/{vehicleNumber}")]
    public IActionResult AddFuelRecord([FromBody] FuelRecord record, string vehicleNumber)
    {
        if (record.Date == default || record.Date == DateTime.MinValue || record.Date == DateTime.MaxValue)
        {
            record.Date = DateTime.UtcNow;
        }
        
        _fuelService.AddFuelRecord(record);
        return Ok("Record added successfully");
    }

    [HttpGet("/{vehicleNumber}/history")]
    public IActionResult GetFuelHistory(string vehicleNumber)
    {
        var history = _fuelService.GetFuelHistory(vehicleNumber);
        return Ok(history);
    }
}