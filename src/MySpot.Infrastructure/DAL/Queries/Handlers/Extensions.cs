using MySpot.Application.DTO;
using MySpot.Core.Users.Entities;

namespace MySpot.Infrastructure.DAL.Queries.Handlers;

internal static class Extensions
{
    public static UserDto AsDto(this User user)
        => user.Map<UserDto>();

    public static UserDetailsDto AsDetailsDto(this User user)
    {
        var dto = user.Map<UserDetailsDto>();
        dto.Email = user.Email;
        dto.Role = user.Role;
        dto.JobTitle = user.JobTitle;

        return dto;
    }

    private static T Map<T>(this User user) where T : UserDto, new()
        => new()
        {
            Id = user.Id,
            FullName = user.FullName
        };
}