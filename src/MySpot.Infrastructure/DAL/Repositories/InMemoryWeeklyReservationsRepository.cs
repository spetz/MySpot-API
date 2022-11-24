using MySpot.Core.Reservations.Entities;
using MySpot.Core.Reservations.Repositories;
using MySpot.Core.Reservations.Types;
using MySpot.Core.Reservations.ValueObjects;
using MySpot.Core.Shared.Time;

namespace MySpot.Infrastructure.DAL.Repositories;

public sealed class InMemoryWeeklyReservationsRepository : IWeeklyReservationsRepository
{
    private static readonly List<WeeklyReservations> WeeklyReservations = new();
    private readonly IClock _clock = new DateTimeClock();

    public Task<WeeklyReservations> GetForCurrentWeekAsync(UserId userId)
    {
        var week = new Week(_clock.Current());
        return Task.FromResult(WeeklyReservations.SingleOrDefault(x => x.UserId == userId && x.Week == week));
    }

    public Task<WeeklyReservations> GetForLastWeekAsync(UserId userId)
    {
        var week = new Week(_clock.Current().AddDays(-7));
        return Task.FromResult(WeeklyReservations.SingleOrDefault(x => x.UserId == userId && x.Week == week));
    }

    public Task AddAsync(WeeklyReservations weeklyReservations)
    {
        WeeklyReservations.Add(weeklyReservations);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(WeeklyReservations weeklyReservations)
    {
        return Task.CompletedTask;
    }
}