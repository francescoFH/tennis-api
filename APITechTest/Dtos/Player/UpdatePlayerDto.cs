using System;
using System.ComponentModel.DataAnnotations;

namespace APITechTest.Dtos
{
    public record UpdatePlayerDto
    {
        [Required]
        public string FirstName { get; init; }
        
        [Required]
        public string LastName { get; init; }

        [Required]
        public string Nationality { get; init; }

        [Required]
        public DateTime BirthDate { get; init; }
        
        public int Points { get; set; }

        public int Games { get; set; }

    }
}