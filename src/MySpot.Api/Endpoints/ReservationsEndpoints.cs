using MySpot.Application.DTO;
using MySpot.Application.Services;

namespace MySpot.Api.Endpoints;

internal static class ReservationsEndpoints
{
    public static IEndpointRouteBuilder MapReservationsApi(this IEndpointRouteBuilder app)
    {
        var reservations = app.MapGroup("api/reservations");

        reservations.MapPost("", async (ReservationDto dto, IWeeklyReservationsService reservationsService)
            =>
        {
            await reservationsService.MakeReservationAsync(dto);
            return Results.NoContent();
        });

        return app;
    }
}