

using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Reservations.Exceptions;

public sealed class InvalidLicensePlateException : CustomException
{
    public string LicensePlate { get; }

    public InvalidLicensePlateException(string licensePlate) : base($"License plate: {licensePlate} is invalid.")
        => LicensePlate = licensePlate;
}