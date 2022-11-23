using MySpot.Core.Reservations.Entities;
using MySpot.Core.Reservations.Types;

namespace MySpot.Core.Reservations.Repositories;

public interface IWeeklyReservationsRepository
{
    Task<WeeklyReservations> GetForCurrentWeekAsync(UserId userId);
    Task<WeeklyReservations> GetForLastWeekAsync(UserId userId);
    Task AddAsync(WeeklyReservations weeklyReservations);
    Task UpdateAsync(WeeklyReservations weeklyReservations);
}