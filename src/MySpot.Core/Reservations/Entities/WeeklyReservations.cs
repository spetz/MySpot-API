using MySpot.Core.Reservations.Events;
using MySpot.Core.Reservations.Exceptions;
using MySpot.Core.Reservations.Policies;
using MySpot.Core.Reservations.Types;
using MySpot.Core.Reservations.ValueObjects;
using MySpot.Core.Shared.Time;

namespace MySpot.Core.Reservations.Entities;

public class WeeklyReservations
{
    private readonly HashSet<Reservation> _reservations = new();
    
    private readonly HashSet<IDomainEvent> _domainEvents = new();
    
    public WeeklyReservationsId Id { get; private set; }
    public UserId UserId { get; private set; }
    public string JobTitle { get; private set; } // could be considered as "trusted" value, thus no need for VO in this case
    public Week Week { get; private set; }

    public IEnumerable<Reservation> Reservations => _reservations;
    
    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

    private WeeklyReservations()
    {
    }

    public WeeklyReservations(WeeklyReservationsId id, UserId userId, string jobTitle, 
        Week week)
    {
        Id = id;
        UserId = userId;
        JobTitle = jobTitle;
        Week = week;
    }

    internal void AddReservation(Reservation reservation, IClock clock, IEnumerable<IReservationPolicy> policies)
    {
        if (reservation.Date.Value < clock.Current()|| reservation.Date < Week.From || reservation.Date > Week.To)
        {
            throw new InvalidReservationDateException(reservation.Date);
        }
        
        if (_reservations.Any(x => x.Date == reservation.Date && x.ParkingSpotId == reservation.ParkingSpotId))
        {
            throw new ParkingSpotAlreadyReservedException(reservation.ParkingSpotId, reservation.Date);
        }

        var jobTitlePolicy = policies.SingleOrDefault(x => x.CanBeApplied(JobTitle));

        if (jobTitlePolicy is null)
        {
            throw new NoReservationPolicyFoundException(JobTitle);
        }

        if (!jobTitlePolicy.CanReserve(Reservations))
        {
            throw new CannotMakeReservationException(reservation.ParkingSpotId);
        }
        _reservations.Add(reservation);
        _domainEvents.Add(new ReservationCreated(this, reservation));
    }
}