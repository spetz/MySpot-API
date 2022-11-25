using MySpot.Application.DTO;
using MySpot.Application.Services;

namespace MySpot.Api.Endpoints;

internal static class ParkingSpotsEndpoints
{
    public static IEndpointRouteBuilder MapParkingSpotsApi(this IEndpointRouteBuilder app)
    {
        var parkingSpots = app.MapGroup("api/parking-spots");

        parkingSpots.MapGet("{id:guid}", (Guid id)
            => Results.Ok()).WithName("Get parking spot");

        parkingSpots.MapGet("", async (IParkingSpotsService parkingSpotsService)
            => Results.Ok(await parkingSpotsService.GetAllAsync()));

        parkingSpots.MapPost("", async (ParkingSpotDto dto, IParkingSpotsService parkingSpotsService)
            =>
        {
            await parkingSpotsService.AddAsync(dto);
            return Results.NoContent();
        });

        parkingSpots.MapDelete("{id:guid}", async (Guid id, IParkingSpotsService parkingSpotsService)
            =>
        {
            await parkingSpotsService.DeleteAsync(id);
            return Results.NoContent();
        });

        return app;
    }
}