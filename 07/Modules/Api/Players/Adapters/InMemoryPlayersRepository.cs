public class InMemoryPlayersRepository : IPlayersRepository
{
    public Player[] GetAll()
        => new Player[3] 
            {
                new Player {Name = "Rodrigo", Surname = "Palacio", Age = 40},
                new Player {Name = "Matteo", Surname = "Tramoni", Age = 22},
                new Player {Name = "Andrea", Surname = "Cistana", Age = 25},
            };
}