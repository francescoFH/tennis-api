using System;
using System.ComponentModel.DataAnnotations;

namespace APITechTest.Dtos
{
    public record CreateMatchDto
    {
        [Required]
        public Guid WinnerId { get; init; }
        [Required]
        public Guid LooserId { get; init; }
        [Required]
        public DateTime MatchDate { get; init; }
    }
}