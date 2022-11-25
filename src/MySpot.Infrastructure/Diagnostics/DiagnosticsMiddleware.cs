using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MySpot.Infrastructure.Diagnostics;

internal sealed class DiagnosticsMiddleware : IMiddleware
{
    private readonly ILogger<DiagnosticsMiddleware> _logger;

    public DiagnosticsMiddleware(ILogger<DiagnosticsMiddleware> logger)
    {
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;
        var stopwatch = new Stopwatch();
        _logger.LogInformation("Started processing a request {RequestMethod} {RequestPath}",
            method, path);
        stopwatch.Start();
        await next(context);
        stopwatch.Stop();
        _logger.LogInformation("Completed processing a request {RequestMethod} {RequestPath} in {RequestTime} ms",
            method, path, stopwatch.ElapsedMilliseconds);
    }
}