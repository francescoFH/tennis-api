using System;
using System.Collections.Generic;
using APITechTest.Entities;

public interface IPlayersRepository
    {
        Player GetPlayer(Guid id);
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetPlayersByNationality(String nationality);
        IEnumerable<Player> GetPlayersByRank(String rank);
        void CreatePlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Guid id);
    }