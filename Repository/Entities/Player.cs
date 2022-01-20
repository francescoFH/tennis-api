using System;

namespace Repository.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NationalityId { get; set; }

        public Nationality Nationality { get; set; }

        public DateTime BirthDate { get; set; }

        public int Points { get; set; }

        public int Games { get; set; }
    }
}
