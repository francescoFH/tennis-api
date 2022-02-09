using System;

namespace APITechTest.Dtos
{
    public record PlayerDto    // DTO: the benefit become evident once I'll have a DB and need do make changes as I won't have to touch this contract.
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Nationality { get; init; }
        public DateTime BirthDate { get; init; }
        public int Points { get; set; }
        public int Games { get; set; }
        public string Rank { get; init; }
    }
}