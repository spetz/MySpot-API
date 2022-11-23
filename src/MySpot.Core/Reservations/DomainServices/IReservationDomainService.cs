using MySpot.Core.Reservations.Entities;

namespace MySpot.Core.Reservations.DomainServices;

public interface IReservationDomainService
{
    void Reserve(WeeklyReservations currentWeekReservation, WeeklyReservations lastWeekReservations,
        Reservation reservation);
}