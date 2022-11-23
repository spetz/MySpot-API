using MySpot.Core.Reservations.Entities;
using MySpot.Core.Shared.Time;

namespace MySpot.Core.Reservations.Policies;

public sealed class RegularEmployeeReservationPolicy : IReservationPolicy
{
    private readonly IClock _clock;

    public RegularEmployeeReservationPolicy(IClock clock)
        => _clock = clock;

    public bool CanBeApplied(string jobTitle)
        => jobTitle is "employee";

    public bool CanReserve(IEnumerable<Reservation> reservations)
    {
        var reservationCount = reservations.Count();

        return reservationCount <= 2 && _clock.Current().Hour >= 13;
    }
}