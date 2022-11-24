var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/api", () => "Hello World!");

app.MapControllers();

app.Run();