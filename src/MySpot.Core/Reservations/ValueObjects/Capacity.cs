using MySpot.Core.Reservations.Exceptions;

namespace MySpot.Core.Reservations.ValueObjects;

public record Capacity
{
    public int Value { get; }

    public Capacity(int value)
    {
        if (value is < 1 or > 6)
        {
            throw new InvalidCapacityException(value);
        }

        Value = value;
    }

    public static implicit operator int(Capacity capacity)
        => capacity.Value;

    public static implicit operator Capacity(int capacity)
        => new(capacity);
}