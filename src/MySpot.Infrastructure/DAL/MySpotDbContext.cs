using Microsoft.EntityFrameworkCore;
using MySpot.Core.ParkingSpots.Entities;

namespace MySpot.Infrastructure.DAL;

public class MySpotDbContext : DbContext
{
    public DbSet<ParkingSpot> ParkingSpots { get; set; }

    public MySpotDbContext(DbContextOptions<MySpotDbContext> options) : base(options)
    {
    }
}