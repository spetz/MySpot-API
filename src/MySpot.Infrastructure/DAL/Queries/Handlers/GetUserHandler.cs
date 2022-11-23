using MySpot.Application.DTO;
using MySpot.Application.Queries;
using MySpot.Application.Shared.Queries;

namespace MySpot.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDetailsDto>
{
    public async Task<UserDetailsDto> HandleAsync(GetUser query)
    {
        await Task.CompletedTask;
        return default;
    }
}