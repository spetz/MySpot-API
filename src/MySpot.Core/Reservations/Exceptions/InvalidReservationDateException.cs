using MySpot.Core.Reservations.ValueObjects;
using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Reservations.Exceptions;

public sealed class InvalidReservationDateException : CustomException
{
    public InvalidReservationDateException(Date date) 
        : base($"Reservation date: {date.Value} is invalid.")
    {
    }
}