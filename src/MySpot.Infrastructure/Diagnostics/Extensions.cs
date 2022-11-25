using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Infrastructure.Diagnostics;

public static class Extensions
{
    public static IServiceCollection AddDiagnosticsMiddleware(this IServiceCollection services)
        => services.AddSingleton<DiagnosticsMiddleware>();

    public static IApplicationBuilder UseDiagnosticsMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<DiagnosticsMiddleware>();
}