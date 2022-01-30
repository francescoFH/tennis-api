using System;

namespace APITechTest.Entities
{
    public record Player
    {
        public Guid Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Nationality { get; init; }

        public DateTime BirthDate { get; init; }

        public int Points { get; init; }

        public int Games { get; init; }

        public string GetRank()
        {
            if (Games < 3)
            {
                return "Unranked";
            }
            else
            {
                if (Points >= 0 && Points <= 2999)
                {
                    return "Bronze";
                }
                else if (Points >= 3000 && Points <= 4999)
                {
                    return "Silver";
                }
                else if (Points >= 5000 && Points <= 9999)
                {
                    return "Gold";
                }
                else
                {
                    return "Supersonic Legend";
                }
            }
        }
    }
}
