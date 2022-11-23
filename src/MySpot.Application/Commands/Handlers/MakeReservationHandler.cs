using MySpot.Application.Shared.Commands;

namespace MySpot.Application.Commands.Handlers;

internal sealed class MakeReservationHandler : ICommandHandler<MakeReservation>
{
    public async Task HandleAsync(MakeReservation command)
    {
        await Task.CompletedTask;
    }
}