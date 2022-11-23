using MySpot.Core.Reservations.Types;
using MySpot.Core.Reservations.ValueObjects;

namespace MySpot.Core.Reservations.Entities;

public sealed class Reservation
{
    public ReservationId Id { get; private set; }
    public ParkingSpotId ParkingSpotId { get; private set; }
    public Capacity Capacity { get; private set; }
    public LicensePlate LicensePlate { get; private set; }
    public Date Date { get; private set; }
    public string Note { get; private set; }
    public ReservationStatus Status { get; private set; }

    private Reservation()
    {
    }

    public Reservation(ReservationId id, ParkingSpotId parkingSpotId, Capacity capacity, 
        LicensePlate licensePlate, Date date, string note)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Capacity = capacity;
        LicensePlate = licensePlate;
        Date = date;
        Note = note;
        Status = ReservationStatus.Pending;
    }

    internal void ChangeNote(string note)
        => Note = note;
    
    internal void ChangeLicensePlate(LicensePlate licensePlate)
        => LicensePlate = licensePlate;

    internal void MarkAsVerified()
        => Status = ReservationStatus.Verified;

    internal void MarkAsInvalid()
        => Status = ReservationStatus.Invalid;
}
