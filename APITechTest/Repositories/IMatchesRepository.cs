using System;
using System.Collections.Generic;
using APITechTest.Entities;

public interface IMatchesRepository
{
    Match GetMatch(Guid id);
    IEnumerable<Match> GetMatches();
}