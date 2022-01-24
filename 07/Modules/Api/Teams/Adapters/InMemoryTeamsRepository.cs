public class InMemoryTeamsRepository : ITeamsRepository
{
    public Team[] GetAll()
        => new Team[3] 
            {
                new Team {Name = "Brescia Calcio", League = "Serie B"},
                new Team {Name = "AC Milan", League = "Serie A"},
                new Team {Name = "Chelsea FC", League = "Premier League"},
            };
}