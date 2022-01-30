using System;

namespace APITechTest.Dtos
{
    public record PlayerDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Nationality { get; init; }
        // public int NationalityId { get; init; }
        // public Nationality Nationality { get; init; }
        public DateTime BirthDate { get; init; }
        public int Points { get; init; }
        public int Games { get; init; }
        // public string Rank { get; init; }
    }
}