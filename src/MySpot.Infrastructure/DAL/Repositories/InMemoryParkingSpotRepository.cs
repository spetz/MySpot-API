using MySpot.Core.ParkingSpots.Entities;
using MySpot.Core.ParkingSpots.Repositories;

namespace MySpot.Infrastructure.DAL.Repositories;

public sealed class InMemoryParkingSpotRepository : IParkingSpotRepository
{
    private static readonly List<ParkingSpot> ParkingSpots = new()
    {
        new ParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000001"), "P1", 1),
        new ParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000002"), "P2", 2),
        new ParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000003"), "P3", 3),
        new ParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000004"), "P4", 4),
        new ParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000005"), "P5", 5),
    };

    public Task<ParkingSpot> GetAsync(Guid id) => Task.FromResult(ParkingSpots.SingleOrDefault(x => x.Id == id));

    public Task<IEnumerable<ParkingSpot>> GetAllAsync() => Task.FromResult(ParkingSpots.AsEnumerable());

    public Task AddAsync(ParkingSpot parkingSpot)
    {
        ParkingSpots.Add(parkingSpot);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(ParkingSpot parkingSpot)
    {
        ParkingSpots.Remove(parkingSpot);
        return Task.CompletedTask;
    }
}