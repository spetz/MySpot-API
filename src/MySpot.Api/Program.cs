using MySpot.Application;
using MySpot.Core;
using MySpot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCoreLayer()
    .AddApplicationLayer()
    .AddInfrastructureLayer()
    .AddControllers();

var app = builder.Build();

app.MapGet("/api", () => "Hello World!");

app.MapControllers();

app.Run();