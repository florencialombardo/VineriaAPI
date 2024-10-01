using VineriaAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WineRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
