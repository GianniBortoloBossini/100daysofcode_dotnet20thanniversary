public class PlayersModule : ICarterModule
{
    private const string MODULE_NAME  = "players";

    public void AddRoutes(IEndpointRouteBuilder app) => app.MapGet($"/{MODULE_NAME}", (IPlayersService playersService) => playersService.GetAll());
}
