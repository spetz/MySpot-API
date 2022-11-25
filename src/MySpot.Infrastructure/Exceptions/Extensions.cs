using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Infrastructure.Exceptions;

public static class Extensions
{
    public static IServiceCollection AddErrorHandlerMiddleware(this IServiceCollection services)
        => services.AddSingleton<ErrorHandlerMiddleware>();

    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlerMiddleware>();
}