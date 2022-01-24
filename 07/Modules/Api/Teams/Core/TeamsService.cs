public interface ITeamsService
{
    Team[] GetAll();
}

public class TeamsService : ITeamsService
{
    private readonly ITeamsRepository repository;

    public TeamsService(ITeamsRepository repository)
    {
        this.repository = repository;
    }

    public Team[] GetAll() => repository.GetAll();
}