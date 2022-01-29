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

        // public int NationalityId { get; init; }

        // public Nationality Nationality { get; init; }

        [Required]
        public DateTime BirthDate { get; init; }
        
        [Required]
        [Range(1200, 999999)]
        public int Points { get; init; }

        public int Games { get; init; }
    }
}