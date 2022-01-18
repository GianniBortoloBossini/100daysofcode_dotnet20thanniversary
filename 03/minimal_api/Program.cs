var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<WeatherForecastService>();

var app = builder.Build();

app.MapGet("/", (WeatherForecastService service) => Results.Ok(service.Get()));

app.Run();
