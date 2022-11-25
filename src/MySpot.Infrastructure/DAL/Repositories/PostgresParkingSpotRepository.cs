using Microsoft.EntityFrameworkCore;
using MySpot.Core.ParkingSpots.Entities;
using MySpot.Core.ParkingSpots.Repositories;

namespace MySpot.Infrastructure.DAL.Repositories;

internal sealed class PostgresParkingSpotRepository : IParkingSpotRepository
{
    private readonly MySpotDbContext _dbContext;

    public PostgresParkingSpotRepository(MySpotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ParkingSpot> GetAsync(Guid id)
        => _dbContext.ParkingSpots.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<ParkingSpot>> GetAllAsync()
        => await _dbContext.ParkingSpots.ToListAsync();

    public async Task AddAsync(ParkingSpot parkingSpot)
    {
        await _dbContext.ParkingSpots.AddAsync(parkingSpot);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ParkingSpot parkingSpot)
    {
        _dbContext.ParkingSpots.Remove(parkingSpot);
        await _dbContext.SaveChangesAsync();
    }
}