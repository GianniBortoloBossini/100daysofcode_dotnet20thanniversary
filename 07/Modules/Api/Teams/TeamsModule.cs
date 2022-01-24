public class TeamsModule : ICarterModule
{
    private const string MODULE_NAME  = "teams";

    public void AddRoutes(IEndpointRouteBuilder app) => app.MapGet($"/{MODULE_NAME}", (ITeamsService teamsService) => teamsService.GetAll());
}
