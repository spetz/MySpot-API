using Microsoft.AspNetCore.Mvc;
using MySpot.Application.DTO;
using MySpot.Application.Services;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("reservations")]
public class ReservationsController : ControllerBase
{
    private readonly IWeeklyReservationsService _weeklyReservationsService;

    public ReservationsController(IWeeklyReservationsService weeklyReservationsService)
    {
        _weeklyReservationsService = weeklyReservationsService;
    }

    [HttpPost]
    public async Task<ActionResult> Post(ReservationDto dto)
    {
        dto.Id = Guid.NewGuid();
        await _weeklyReservationsService.MakeReservationAsync(dto);
        return NoContent();
    }
}