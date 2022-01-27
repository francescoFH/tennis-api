using System;

namespace Repository.Entities
{
    public class Player
    {
        public int Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public int NationalityId { get; init; }

        public Nationality Nationality { get; init; }

        public DateTime BirthDate { get; init; }

        public int Points { get; init; }

        public int Games { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}
