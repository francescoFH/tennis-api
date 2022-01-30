using System;
using System.Collections.Generic;
using System.Linq;
using APITechTest.Entities;

namespace APITechTest.Repositories
{

    public class InMemPlayersRepository : IPlayersRepository
    {
        private readonly List<Player> players = new()
        {

            new Player
            {
                Id = Guid.NewGuid(),
                FirstName = "Rafael",
                LastName = "Nadal",
                Nationality = "Spain",
                BirthDate = DateTime.Parse("1986-06-03"),
                Points = 4875,
                Games = 1240
            },
            new Player
            {
                Id = Guid.NewGuid(),
                FirstName = "Novak",
                LastName = "Djokovic",
                Nationality = "Serbia",
                BirthDate = DateTime.Parse("1987-05-22"),
                Points = 11015,
                Games = 1188

            },
            new Player
            {
                Id = Guid.NewGuid(),
                FirstName = "Roberto Bautista",
                LastName = "Agut",
                Nationality = "Spain",
                BirthDate = DateTime.Parse("1988-04-14"),
                Points = 2385,
                Games = 546
            },
            new Player
            {
                Id = Guid.NewGuid(),
                FirstName = "Jan-Lennard",
                LastName = "Struff",
                Nationality = "Germany",
                BirthDate = DateTime.Parse("1990-04-25"),
                Points = 1149,
                Games = 359
            }
        };

        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }
        public IEnumerable<Player> GetPlayersByNationality(String nationality)
        {
            return players.Where(player => player.Nationality == nationality);
        }

        public IEnumerable<Player> GetPlayersByRank(String rank)
        {
            return players.Where(player => player.GetRank() == rank);
        }        
            
        public Player GetPlayer(Guid id)
        {
            return players.SingleOrDefault(player => player.Id == id);
        }

        public void CreatePlayer(Player player)
        {
            players.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            var index = players.FindIndex(existingPlayer => existingPlayer.Id == player.Id);
            players[index] = player;
        }

        public void DeletePlayer(Guid id)
        {
            var index = players.FindIndex(existingPlayer => existingPlayer.Id == id);
            players.RemoveAt(index);
        }

    }
}    