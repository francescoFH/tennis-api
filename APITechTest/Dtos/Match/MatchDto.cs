using System;

namespace APITechTest.Dtos
{
    public record MatchDto
    {
        public Guid Id { get; init; }
        public Guid WinnerId { get; init; }
        public Guid LooserId { get; init; }
        public DateTime MatchDate { get; init; }
    }
}