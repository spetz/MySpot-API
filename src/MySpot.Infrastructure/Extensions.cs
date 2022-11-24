using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Services;

namespace MySpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        return services;
    }
}