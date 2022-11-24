using MySpot.Application;
using MySpot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer()
    .AddControllers();

var app = builder.Build();

app.MapGet("/api", () => "Hello World!");

app.MapControllers();

app.Run();