using APITechTest.Dtos;
using APITechTest.Entities;

namespace Catalog
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
                Games = player.Games
            };
        }
    }
}