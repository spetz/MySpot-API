using MySpot.Core.Reservations.Types;
using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Reservations.Exceptions;

public sealed class CannotMakeReservationException : CustomException
{
    public ParkingSpotId ParkingSpotId { get; }

    public CannotMakeReservationException(ParkingSpotId parkingSpotId) 
        : base($"Cannot reserve parking spot with ID: {parkingSpotId} due to reservation policy.")
    {
        ParkingSpotId = parkingSpotId;
    }
}