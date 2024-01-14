using FuelTracker.Application;
using FuelTracker.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FuelTracker.WebApi.Controllers;

[Route("api/v1/vehicle")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;

    public FuelController(IFuelService fuelService)
    {
        _fuelService = fuelService ?? throw new ArgumentNullException(nameof(fuelService));
    }

    [HttpPost("{vehicleNumber}")]
    public IActionResult AddFuelRecord([FromBody] FuelRecord record, string vehicleNumber)
    {
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