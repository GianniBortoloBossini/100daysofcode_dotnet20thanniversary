public static class teamsConfigurationExtensions
{
    public static IServiceCollection AddTeamsConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ITeamsService, TeamsService>();
        services.AddScoped<ITeamsRepository, InMemoryTeamsRepository>();
        return services;
    }
}