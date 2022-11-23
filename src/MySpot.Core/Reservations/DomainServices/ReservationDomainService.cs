using MySpot.Core.Reservations.Entities;
using MySpot.Core.Reservations.Exceptions;
using MySpot.Core.Reservations.Policies;
using MySpot.Core.Shared.Time;

namespace MySpot.Core.Reservations.DomainServices;

public sealed class ReservationDomainService : IReservationDomainService
{
    private readonly IClock _clock;
    private readonly IEnumerable<IReservationPolicy> _policies;

    public ReservationDomainService(IClock clock, IEnumerable<IReservationPolicy> policies)
    {
        _clock = clock;
        _policies = policies;
    }

    public void Reserve(WeeklyReservations currentWeekReservation, WeeklyReservations lastWeekReservations,
        Reservation reservation)
    {
        if (lastWeekReservations is not null)
        {
            var hasAnyInvalidReservation = lastWeekReservations.Reservations
                .Any(x => x.Status is ReservationStatus.Invalid);

            if (hasAnyInvalidReservation)
            {
                throw new CannotMakeReservationException(reservation.ParkingSpotId);
            }
        }
        
        currentWeekReservation.AddReservation(reservation, _clock, _policies);
    }
}