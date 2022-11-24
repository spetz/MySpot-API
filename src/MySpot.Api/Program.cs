using MySpot.Api;
using MySpot.Application;
using MySpot.Core;
using MySpot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/api", () => "Hello World!");

app.MapControllers();

app.Run();