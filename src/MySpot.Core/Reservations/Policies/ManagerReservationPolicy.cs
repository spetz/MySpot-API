using MySpot.Core.Reservations.Entities;

namespace MySpot.Core.Reservations.Policies;

public sealed class ManagerReservationPolicy : IReservationPolicy
{
    public bool CanBeApplied(string jobTitle)
        => jobTitle is "manager";

    public bool CanReserve(IEnumerable<Reservation> reservations)
    {
        var reservationsCount = reservations.Count();
        return reservationsCount <= 4;
    }
}