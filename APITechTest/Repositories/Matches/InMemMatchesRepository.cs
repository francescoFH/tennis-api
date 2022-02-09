using System;
using System.Collections.Generic;
using System.Linq;
using APITechTest.Entities;

namespace APITechTest.Repositories
{

    public class InMemMatchesRepository : IMatchesRepository
    {
        private readonly List<Match> matches = new();

        public IEnumerable<Match> GetMatches()
        {
            return matches;
        }

        public Match GetMatch(Guid id)
        {
            return matches.SingleOrDefault(match => match.Id == id);
        }

        public void CreateMatch(Match match)
        {
            matches.Add(match);
        }

        public void UpdateMatch(Match match)
        {
            var index = matches.FindIndex(existingMatch => existingMatch.Id == match.Id);
            matches[index] = match;
        }

        public void DeleteMatch(Guid id)
        {
            var index = matches.FindIndex(existingMatch => existingMatch.Id == id);
            matches.RemoveAt(index);
        }

        public int CalculatePoints(int points)
        {
            var newPoints = points * 0.10;
            return (int)newPoints;
        }
    }
}