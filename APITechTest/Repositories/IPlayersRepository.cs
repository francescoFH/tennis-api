using System.Collections.Generic;
using APITechTest.Entities;

public interface IPlayersRepository
    {
        Player GetPlayer(int id);
        IEnumerable<Player> GetPlayers();
    }