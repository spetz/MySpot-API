using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.ParkingSpots.Repositories;
using MySpot.Core.Reservations.Repositories;
using MySpot.Core.Shared.Time;
using MySpot.Core.Users.Repositories;
using MySpot.Infrastructure.DAL;
using MySpot.Infrastructure.DAL.Repositories;
using MySpot.Infrastructure.Time;

namespace MySpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddScoped<IParkingSpotRepository, InMemoryParkingSpotRepository>()
            .AddScoped<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IWeeklyReservationsRepository, InMemoryWeeklyReservationsRepository>()
            .AddSingleton<IClock, DateTimeClock>()
            .AddPostgres(configuration);
}