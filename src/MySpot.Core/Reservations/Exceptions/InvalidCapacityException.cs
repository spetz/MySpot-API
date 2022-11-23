using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Reservations.Exceptions;

public sealed class InvalidCapacityException : CustomException
{
    public InvalidCapacityException(int value) 
        : base($"Given capacity ({value}) is invalid.")
    {
    }
}