namespace MySpot.Application.DTO;

public class UserDetailsDto : UserDto
{
    public string Email { get; set; }
    public string Role { get; set; }
    public string JobTitle { get; set; }
}