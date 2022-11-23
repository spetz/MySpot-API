using MySpot.Core.Reservations.Entities;

namespace MySpot.Application.DTO;

public class ReservationDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ParkingSpotId { get; set; }
    public int Capacity { get; set; }
    public string LicensePlate { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Note { get; set; }
    public ReservationStatus Status { get; set; }
}