using MySpot.Application.DTO;
using MySpot.Application.Exceptions;
using MySpot.Core.ParkingSpots.Entities;
using MySpot.Core.ParkingSpots.Repositories;

namespace MySpot.Application.Services;

internal sealed class ParkingSpotsService : IParkingSpotsService
{
    private readonly IParkingSpotRepository _parkingSpotRepository;

    public ParkingSpotsService(IParkingSpotRepository parkingSpotRepository)
    {
        _parkingSpotRepository = parkingSpotRepository;
    }
    
    public async Task<IEnumerable<ParkingSpotDto>> GetAllAsync()
    {
        var parkingSpots = await _parkingSpotRepository.GetAllAsync();
        return parkingSpots.OrderBy(x => x.DisplayOrder).Select(x => new ParkingSpotDto
        {
            Id = x.Id,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder
        });
    }

    public async Task AddAsync(ParkingSpotDto parkingSpot)
    {
        await _parkingSpotRepository.AddAsync(new ParkingSpot(parkingSpot.Id,
            parkingSpot.Name, parkingSpot.DisplayOrder));
    }

    public async Task DeleteAsync(Guid parkingSpotId)
    {
        var parkingSpot = await _parkingSpotRepository.GetAsync(parkingSpotId);
        if (parkingSpot is null)
        {
            throw new ParkingSpotNotFoundException(parkingSpotId);
        }

        await _parkingSpotRepository.DeleteAsync(parkingSpot);
    }
}