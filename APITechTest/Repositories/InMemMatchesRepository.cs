using System;
using System.Collections.Generic;
using System.Linq;
using APITechTest.Entities;

namespace APITechTest.Repositories
{

    public class InMemMatchesRepository : IMatchesRepository
    {
        private readonly List<Match> matches = new()
        {

            new Match
            {
                Id = Guid.NewGuid(),
                MatchDate = DateTime.Parse("2021-05-22")
            }
        };

        public IEnumerable<Match> GetMatches()
        {
            return matches;
        }

        public Match GetMatch(Guid id)
        {
            return matches.SingleOrDefault(match => match.Id == id);
        }

    }
}