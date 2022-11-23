namespace MySpot.Core.Shared.Time;

public sealed class DateTimeClock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}