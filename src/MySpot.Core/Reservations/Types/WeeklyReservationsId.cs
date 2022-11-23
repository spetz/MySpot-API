using MySpot.Core.Reservations.Exceptions;

namespace MySpot.Core.Reservations.Types;

public record WeeklyReservationsId
{
    public Guid Value { get; }

    public WeeklyReservationsId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static WeeklyReservationsId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(WeeklyReservationsId date)
        => date.Value;
    
    public static implicit operator WeeklyReservationsId(Guid value)
        => new(value);

    public override string ToString() => Value.ToString("N");
}