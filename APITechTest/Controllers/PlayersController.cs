using System;
using System.Collections.Generic;
using System.Linq;
using APITechTest.Dtos;
using APITechTest.Entities;
using APITechTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APITechTest.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository repository;

        public PlayersController(IPlayersRepository repository)
        {
            this.repository = repository;
        }

        // GET /players
        [HttpGet]
        public IEnumerable<PlayerDto> GetPlayers()
        {
            var players = repository.GetPlayers().Select(player => player.AsDto());            
            return players;
        }
        
        // GET /players/id
        [HttpGet("{id}")]
        public ActionResult<PlayerDto> GetPlayer(Guid id)
        {
            var player = repository.GetPlayer(id);

            if (player is null)
            {
                return NotFound();
            }

            return player.AsDto();
        }

         // GET /players/nationality
        [HttpGet]
        [Route("nationality/{nationality}")]
        public IEnumerable<PlayerDto> GetPlayersByNationality(String nationality)
        {
            var players = repository.GetPlayersByNationality(nationality).Select(player => player.AsDto());
            return players;
        }

         // GET /players/rank
        [HttpGet]
        [Route("rank/{rank}")]
        public IEnumerable<PlayerDto> GetPlayersByRank(String rank)
        {
            var players = repository.GetPlayersByRank(rank).Select(player => player.AsDto());
            return players;
        }

        // POST /players
        [HttpPost]
        public ActionResult<PlayerDto> CreatePlayer(CreatePlayerDto playerDto)
        {
            Player player = new()
            {
                Id = Guid.NewGuid(),
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                Nationality = playerDto.Nationality,
                BirthDate = playerDto.BirthDate,
                Points = 1200,
                Games = 0               
            };
            
            if(repository.isAlreadyRegistered(player))
            {
                return BadRequest("Player is already registered.");
            }  
                    
            if(!repository.isOldEnough(player))
            {
                return BadRequest("Players must be at least 16 years old.");
            }

            repository.CreatePlayer(player);

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id}, player.AsDto());
        }

        // PUT /players/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(Guid id, UpdatePlayerDto playerDto)
        {
            var existingPlayer = repository.GetPlayer(id);

            if (existingPlayer is null)
            {
                return NotFound();
            }

            Player updatedPlayer = existingPlayer with 
            {
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                Nationality = playerDto.Nationality,
                BirthDate = playerDto.BirthDate
                // Points = playerDto.Points,
                // Games = playerDto.Games
            };

            if(repository.isAlreadyRegistered(updatedPlayer))
            {
                return BadRequest("Player is already registered.");
            } 

            if(!repository.isOldEnough(updatedPlayer))
            {
                return BadRequest("Players must be at least 16 years old.");
            }

            repository.UpdatePlayer(updatedPlayer);

            return NoContent();
        }

        // DELETE /players/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(Guid id)
        {
            var existingPlayer = repository.GetPlayer(id);

            if (existingPlayer is null)
            {
                return NotFound();
            }

            repository.DeletePlayer(id);

            return NoContent();
        }
    }
}