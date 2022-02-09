using System;

namespace APITechTest.Entities
{
    public record Match
    {
        public Guid Id { get; init; }
        public Guid WinnerId { get; init; }
        public Guid LooserId { get; init; }
        public DateTime MatchDate { get; init; }
    }
}