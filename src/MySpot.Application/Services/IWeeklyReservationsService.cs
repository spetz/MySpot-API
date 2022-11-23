using MySpot.Application.DTO;

namespace MySpot.Application.Services;

public interface IWeeklyReservationsService
{
    Task MakeReservationAsync(ReservationDto dto);
}