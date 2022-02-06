using System;

namespace APITechTest.Dtos
{
    public record MatchDto
    {
        public Guid Id { get; init; }
        public DateTime MatchDate { get; init; }
    }
}