using System;
using System.Collections.Generic;
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
        public IEnumerable<Player> GetPlayers()
        {
            var players = repository.GetPlayers();
            return players;
        }
        
        // GET /players/id
        [HttpGet("{id}")]
        public ActionResult<Player> GetPlayer(int id)
        {
            var player = repository.GetPlayer(id);

            if (player is null)
            {
                return NotFound();
            }

            return player;
        }
    }
}