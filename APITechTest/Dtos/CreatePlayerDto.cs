using System;
using System.ComponentModel.DataAnnotations;

namespace APITechTest.Dtos
{
    public record CreatePlayerDto
    {
        [Required]
        public string FirstName { get; init; }
        
        [Required]
        public string LastName { get; init; }

        [Required]
        public string Nationality { get; init; }

        [Required]
        public DateTime BirthDate { get; init; }
        // public string Rank { get; internal set; }
    }
}