using Microsoft.Extensions.Logging;
using MySpot.Application.DTO;
using MySpot.Application.Exceptions;
using MySpot.Core.ParkingSpots.Repositories;
using MySpot.Core.Reservations.DomainServices;
using MySpot.Core.Reservations.Entities;
using MySpot.Core.Reservations.Repositories;
using MySpot.Core.Reservations.ValueObjects;
using MySpot.Core.Shared.Time;
using MySpot.Core.Users.Repositories;

namespace MySpot.Application.Services;

internal sealed class WeeklyReservationsService : IWeeklyReservationsService
{
    private readonly IWeeklyReservationsRepository _weeklyReservationsRepository;
    private readonly IParkingSpotRepository _parkingSpotRepository;
    private readonly IUserRepository _userRepository;
    private readonly IReservationDomainService _domainService;
    private readonly IClock _clock;
    private readonly ILogger<WeeklyReservationsService> _logger;

    public WeeklyReservationsService(IWeeklyReservationsRepository weeklyReservationsRepository,
       IParkingSpotRepository parkingSpotRepository, IUserRepository userRepository,
       IReservationDomainService domainService, IClock clock,
       ILogger<WeeklyReservationsService> logger)
    {
        _weeklyReservationsRepository = weeklyReservationsRepository;
        _parkingSpotRepository = parkingSpotRepository;
        _userRepository = userRepository;
        _domainService = domainService;
        _clock = clock;
        _logger = logger;
    }

    public async Task MakeReservationAsync(ReservationDto dto)
    {
        _logger.LogInformation("Making the reservation with ID: {ReservationId} for user: {UserId}...",
            dto.Id, dto.UserId);
        var userId = dto.UserId;
        var user = await _userRepository.GetAsync(userId);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        var parkingSpotId = dto.ParkingSpotId;
        var parkingSpot = await _parkingSpotRepository.GetAsync(parkingSpotId);
        if (parkingSpot is null)
        {
            throw new ParkingSpotNotFoundException(parkingSpotId);
        }
        
        var currentWeeklyReservations = await _weeklyReservationsRepository.GetForCurrentWeekAsync(userId);
        if (currentWeeklyReservations is null)
        {
            // BO call
            var currentWeek = new Week(_clock.Current());
            currentWeeklyReservations = new WeeklyReservations(Guid.NewGuid(), userId, user.JobTitle, currentWeek);
            await _weeklyReservationsRepository.AddAsync(currentWeeklyReservations);
        }

        var lastWeekReservations = await _weeklyReservationsRepository.GetForLastWeekAsync(userId);

        var reservation = new Reservation(dto.Id, dto.ParkingSpotId, dto.Capacity, dto.LicensePlate,
            dto.Date, dto.Note);
        
       _domainService.Reserve(currentWeeklyReservations, lastWeekReservations, reservation);

       await _weeklyReservationsRepository.UpdateAsync(currentWeeklyReservations);
       _logger.LogInformation("Made the reservation with ID: {ReservationId} for user: {UserId}.",
           dto.Id, dto.UserId);
    }
}