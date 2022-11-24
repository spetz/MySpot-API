using MySpot.Application.DTO;
using MySpot.Application.Exceptions;
using MySpot.Core.ParkingSpots.Entities;

namespace MySpot.Application.Services;

public sealed class ParkingSpotsService : IParkingSpotsService
{
    private readonly List<ParkingSpot> _parkingSpots = new();

    public async Task<IEnumerable<ParkingSpotDto>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _parkingSpots.OrderBy(x => x.DisplayOrder).Select(x => new ParkingSpotDto
        {
            Id = x.Id,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder
        });
    }

    public async Task AddAsync(ParkingSpotDto parkingSpot)
    {
        _parkingSpots.Add(new ParkingSpot(parkingSpot.Id, parkingSpot.Name, parkingSpot.DisplayOrder));
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid parkingSpotId)
    {
        var parkingSpot = _parkingSpots.SingleOrDefault(x => x.Id == parkingSpotId);
        if (parkingSpot is null)
        {
            throw new ParkingSpotNotFoundException(parkingSpotId);
        }

        _parkingSpots.Remove(parkingSpot);
        await Task.CompletedTask;
    }
}