using Microsoft.Extensions.Options;
using MySpot.Api;
using MySpot.Application;
using MySpot.Application.DTO;
using MySpot.Core;
using MySpot.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, logger) =>
{
    logger
        .WriteTo.Console();
    // .WriteTo.File("logs/log.txt")
    // .WriteTo.Seq("http://localhost:5341");
});

builder.Services
    .AddCoreLayer()
    .AddApplicationLayer()
    .AddInfrastructureLayer()
    .AddControllers();

var section = builder.Configuration.GetSection("app");

builder.Services
    .Configure<AppOptions>(section);

// var appOptions = new AppOptions();
// section.Bind(appOptions);
// builder.Services.AddSingleton(appOptions);

var app = builder.Build();

app.MapGet("/api", (IOptions<AppOptions> appOptions) => appOptions.Value.Name);

app.MapControllers();

app.Run();