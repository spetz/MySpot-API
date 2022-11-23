using MySpot.Core.Reservations.Entities;

namespace MySpot.Core.Reservations.Policies;

public interface IReservationPolicy
{
    bool CanBeApplied(string jobTitle);
    bool CanReserve(IEnumerable<Reservation> reservations);
}