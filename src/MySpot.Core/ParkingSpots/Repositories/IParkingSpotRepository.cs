using MySpot.Core.ParkingSpots.Entities;

namespace MySpot.Core.ParkingSpots.Repositories;

public interface IParkingSpotRepository
{
    Task<ParkingSpot> GetAsync(Guid id);
    Task<IEnumerable<ParkingSpot>> GetAllAsync();
    Task AddAsync(ParkingSpot parkingSpot);
    Task DeleteAsync(ParkingSpot parkingSpot);
}