using MySpot.Application.DTO;
using MySpot.Application.Exceptions;
using MySpot.Core.ParkingSpots.Entities;
using MySpot.Core.Shared.Time;

namespace MySpot.Application.Services;

internal sealed class ParkingSpotsService : IParkingSpotsService
{
    // Not thread-safe
    private static readonly List<ParkingSpot> ParkingSpots = new();
    
    public async Task<IEnumerable<ParkingSpotDto>> GetAllAsync()
    {
        await Task.CompletedTask;
        return ParkingSpots.OrderBy(x => x.DisplayOrder).Select(x => new ParkingSpotDto
        {
            Id = x.Id,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder
        });
    }

    public async Task AddAsync(ParkingSpotDto parkingSpot)
    {
        ParkingSpots.Add(new ParkingSpot(parkingSpot.Id, parkingSpot.Name, parkingSpot.DisplayOrder));
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid parkingSpotId)
    {
        var parkingSpot = ParkingSpots.SingleOrDefault(x => x.Id == parkingSpotId);
        if (parkingSpot is null)
        {
            throw new ParkingSpotNotFoundException(parkingSpotId);
        }

        ParkingSpots.Remove(parkingSpot);
        await Task.CompletedTask;
    }
}