using MySpot.Application.Shared.Commands;

namespace MySpot.Application.Commands;

public record MakeReservation(Guid Id, Guid UserId, Guid ParkingSpotId, int Capacity, string LicensePlate,
    DateTimeOffset Date, string Note = default) : ICommand;