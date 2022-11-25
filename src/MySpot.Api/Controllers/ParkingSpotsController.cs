using Microsoft.AspNetCore.Mvc;
using MySpot.Application.DTO;
using MySpot.Application.Services;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("parking-spots")]
public class ParkingSpotsController : ControllerBase
{
    private readonly IParkingSpotsService _parkingSpotsService;

    public ParkingSpotsController(IParkingSpotsService parkingSpotsService)
    {
        _parkingSpotsService = parkingSpotsService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ParkingSpotDto>> Get(Guid id)
    {
        await Task.CompletedTask;
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParkingSpotDto>>> Get()
        => Ok(await _parkingSpotsService.GetAllAsync());

    [HttpPost]
    public async Task<ActionResult> Post(ParkingSpotDto dto)
    {
        dto.Id = Guid.NewGuid();
        await _parkingSpotsService.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new {id = dto.Id}, default);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _parkingSpotsService.DeleteAsync(id);
        return NoContent();
    }
}