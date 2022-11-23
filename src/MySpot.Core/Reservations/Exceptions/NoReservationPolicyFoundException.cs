using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Reservations.Exceptions;

public sealed class NoReservationPolicyFoundException : CustomException
{
    public string Participant { get; }

    public NoReservationPolicyFoundException(string participant) 
        : base($"No reservation policy found for participant: {participant}")
    {
        Participant = participant;
    }
}