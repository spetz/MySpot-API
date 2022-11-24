using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.Reservations.DomainServices;
using MySpot.Core.Reservations.Policies;
using MySpot.Core.Shared.Time;

namespace MySpot.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        => services
            .AddScoped<IReservationDomainService, ReservationDomainService>()
            .AddSingleton<IEnumerable<IReservationPolicy>>(sp => new IReservationPolicy[]
            {
                new BossReservationPolicy(),
                new ManagerReservationPolicy(),
                new RegularEmployeeReservationPolicy(sp.GetRequiredService<IClock>())
            });
            // .AddSingleton<IReservationPolicy, BossReservationPolicy>()
            // .AddSingleton<IReservationPolicy, ManagerReservationPolicy>()
            // .AddSingleton<IReservationPolicy, RegularEmployeeReservationPolicy>();
}