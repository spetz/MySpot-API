using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Reservations.Exceptions;

public sealed class ParkingSpotAlreadyReservedException : CustomException
{
    public Guid ParkingSpotId { get; }
    public DateTimeOffset Date { get; }

    public ParkingSpotAlreadyReservedException(Guid parkingSpotId, DateTimeOffset date) : 
        base($"Parking spot with ID: {parkingSpotId} is already reserved for date: {date.Date.ToShortDateString()}")
    {
        ParkingSpotId = parkingSpotId;
        Date = date;
    }
}