using System;
using System.ComponentModel.DataAnnotations;


namespace APITechTest.Dtos
{
    public record UpdateMatchDto
    {
        [Required]
        public DateTime MatchDate { get; init; }
    }
}