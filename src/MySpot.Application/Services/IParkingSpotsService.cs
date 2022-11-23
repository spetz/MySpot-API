using MySpot.Application.DTO;

namespace MySpot.Application.Services;

public interface IParkingSpotsService
{
    Task<IEnumerable<ParkingSpotDto>> GetAllAsync();
    Task AddAsync(ParkingSpotDto parkingSpot);
    Task DeleteAsync(Guid parkingSpotId);
}