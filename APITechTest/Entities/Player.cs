using System;

namespace APITechTest.Entities
{
    public record Player   // Record Types: classes with better support for immutable data models (once you get an intance of this object, it is not possible to modify it)
    {
        public Guid Id { get; init; }    // Init-only properties: You can use a creation expression to construct a new object (set) but you cannot modify after creation (private set).

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Nationality { get; init; }

        public DateTime BirthDate { get; init; }

        public int Points { get; set; }

        public int Games { get; set; }

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
