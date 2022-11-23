using MySpot.Application.DTO;
using MySpot.Application.Shared.Queries;

namespace MySpot.Application.Queries;

public class GetUser : IQuery<UserDetailsDto>
{
    public Guid UserId { get; set; }
}