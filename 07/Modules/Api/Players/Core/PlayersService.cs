public interface IPlayersService
{
    Player[] GetAll();
}

public class PlayersService : IPlayersService
{
    private readonly IPlayersRepository repository;

    public PlayersService(IPlayersRepository repository)
    {
        this.repository = repository;
    }

    public Player[] GetAll() => repository.GetAll();
}