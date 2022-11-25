using Microsoft.Extensions.Options;
using MySpot.Api;
using MySpot.Api.Endpoints;
using MySpot.Application;
using MySpot.Core;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Diagnostics;
using MySpot.Infrastructure.Exceptions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, logger) =>
{
    logger.WriteTo.Console();
    // .WriteTo.File("logs/log.txt")
    // .WriteTo.Seq("http://localhost:5341");
});

builder.Services
    .AddCoreLayer()
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddDiagnosticsMiddleware()
    .AddErrorHandlerMiddleware()
    .AddControllers();

var section = builder.Configuration.GetSection("app");

builder.Services
    .Configure<AppOptions>(section);

// var appOptions = new AppOptions();
// section.Bind(appOptions);
// builder.Services.AddSingleton(appOptions);

var app = builder.Build();

app.UseDiagnosticsMiddleware();
app.UseErrorHandlerMiddleware();

app.MapGet("/api", (IOptions<AppOptions> appOptions) => appOptions.Value.Name);
app.MapParkingSpotsApi();
app.MapReservationsApi();
app.MapControllers();

app.Run();