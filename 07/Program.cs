var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter()
                .AddPlayersConfiguration()
                .AddTeamsConfiguration();

var app = builder.Build();

app.MapCarter();

app.Run();