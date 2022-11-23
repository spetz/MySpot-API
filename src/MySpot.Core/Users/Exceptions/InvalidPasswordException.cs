using MySpot.Core.Shared.Exceptions;

namespace MySpot.Core.Users.Exceptions;

public sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}