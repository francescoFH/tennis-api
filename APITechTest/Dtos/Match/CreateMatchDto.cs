using System;
using System.ComponentModel.DataAnnotations;

namespace APITechTest.Dtos
{
    public record CreateMatchDto
    {
        [Required]
        public DateTime MatchDate { get; init; }

    }
}