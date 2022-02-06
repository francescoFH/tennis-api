using APITechTest.Dtos;
using APITechTest.Entities;

namespace APITechTest
{
    public static class Extensions{
        public static PlayerDto AsDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Nationality = player.Nationality,
                BirthDate = player.BirthDate,
                Points = player.Points,
                Games = player.Games,
                Rank = player.GetRank()
            };
        }

        public static MatchDto AsDto(this Match match)
        {
            return new MatchDto
            {
                Id = match.Id,
                MatchDate = match.MatchDate
            };
        }
    }
}