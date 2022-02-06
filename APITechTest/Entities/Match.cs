using System;

namespace APITechTest.Entities
{
    public record Match
    {
        public Guid Id { get; init; }
        public DateTime MatchDate { get; init; }
    }
}