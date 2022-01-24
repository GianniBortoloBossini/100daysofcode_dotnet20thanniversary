public static class PlayersConfigurationExtensions
{
    public static IServiceCollection AddPlayersConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IPlayersService, PlayersService>();
        services.AddScoped<IPlayersRepository, InMemoryPlayersRepository>();
        return services;
    }
}