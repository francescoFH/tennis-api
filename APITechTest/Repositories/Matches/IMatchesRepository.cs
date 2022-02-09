using System;
using System.Collections.Generic;
using APITechTest.Entities;

public interface IMatchesRepository
{
    Match GetMatch(Guid id);
    IEnumerable<Match> GetMatches();
    void CreateMatch(Match match);
    void UpdateMatch(Match match);
    void DeleteMatch(Guid id);
    int CalculatePoints(int points);
}