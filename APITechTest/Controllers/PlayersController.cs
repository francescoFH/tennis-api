using System;
using System.Collections.Generic;
using System.Linq;
using APITechTest.Dtos;
using APITechTest.Entities;
using APITechTest.Repositories;
using Catalog;
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
        public ActionResult<PlayerDto> GetPlayer(int id)
        {
            var player = repository.GetPlayer(id);

            if (player is null)
            {
                return NotFound();
            }

            return player.AsDto();
        }
    }
}