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
                Id = 1,
                FirstName = "Rafael",
                LastName = "Nadal",
                Nationality = "Spain",
                BirthDate = DateTime.Parse("1986-06-03"),
                Points = 4875,
                Games = 1240
            },
            new Player
            {
                Id = 2,
                FirstName = "Novak",
                LastName = "Djokovic",
                Nationality = "Serbia",
                BirthDate = DateTime.Parse("1987-05-22"),
                Points = 11015,
                Games = 1188
            },
            new Player
            {
                Id = 3,
                FirstName = "Roberto Bautista",
                LastName = "Agut",
                Nationality = "Spain",
                BirthDate = DateTime.Parse("1988-04-14"),
                Points = 2385,
                Games = 546
            },
            new Player
            {
                Id = 4,
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

        public Player GetPlayer(int id)
        {
            return players.SingleOrDefault(player => player.Id == id);
        }

    }
}    