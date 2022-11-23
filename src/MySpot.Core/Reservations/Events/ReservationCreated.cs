using MySpot.Core.Reservations.Entities;

namespace MySpot.Core.Reservations.Events;

public sealed class ReservationCreated : IDomainEvent
{
    public WeeklyReservations WeeklyReservations { get; }
    public Reservation Reservation { get; }

    public ReservationCreated(WeeklyReservations weeklyReservations, Reservation reservation)
    {
        WeeklyReservations = weeklyReservations;
        Reservation = reservation;
    }
}