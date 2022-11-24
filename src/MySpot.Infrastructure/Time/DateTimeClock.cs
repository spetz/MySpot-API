using MySpot.Core.Shared.Time;

namespace MySpot.Infrastructure.Time;

internal sealed class DateTimeClock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}