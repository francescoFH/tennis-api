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
                FirstName = "Pablo Carreno",
                LastName = "Busta",
                Nationality = "Spain",
                BirthDate = DateTime.Parse("1991-07-12"),
                Points = 2305,
                Games = 419
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

        public IEnumerable<Player> GetPlayers()    // IEnumarabele: basic interface to return a collection of players
        {
            return players.OrderByDescending(x => x.Points);
        }

        public Player GetPlayer(Guid id)
        {
            return players.SingleOrDefault(player => player.Id == id);   // SingleOrDefault: if it finds the player it will return it, if it doesn't it will return null - returns player whwere player.Id = id of the parameter
        }

        public IEnumerable<Player> GetPlayersByNationality(String nationality)
        {
            return players.OrderByDescending(x => x.Points).Where(player => player.Nationality == nationality);
        }

        public IEnumerable<Player> GetPlayersByRank(String rank)
        {
            return players.OrderByDescending(x => x.Points).Where(player => player.GetRank() == rank);
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

        public Boolean isOldEnough(Player player)
        {
            var today = DateTime.Today;
            var PlayerAge = today.Year - player.BirthDate.Year;
            if (PlayerAge is < 16)
            {
                return false;
            } else {
                return true;
            }
        }

        public Boolean isAlreadyRegistered(Player player)
        {
            var players = GetPlayers().Select(player => player.AsDto());
            var exists=players.Any(x=>x.FirstName==player.FirstName&&x.LastName==player.LastName);
            if(exists)
            {
                return true;
            } else {
                return false;
            }
        }

    }
}    