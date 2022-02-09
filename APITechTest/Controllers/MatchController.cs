using System;
using System.Collections.Generic;
using System.Linq;
using APITechTest.Dtos;
using APITechTest.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APITechTest.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesRepository matchRepository;
        private readonly IPlayersRepository playerRepository;

        public MatchesController(IMatchesRepository matchRepository, IPlayersRepository playerRepository)
        {
            this.matchRepository = matchRepository;
            this.playerRepository = playerRepository;
        }

        // GET /matches
        [HttpGet]
        public IEnumerable<MatchDto> GetMatches()
        {
            var matches = matchRepository.GetMatches().Select(match => match.AsDto());
            return matches;
        }

        // GET /macthes/id
        [HttpGet("{id}")]
        public ActionResult<MatchDto> GetMatch(Guid id)
        {
            var match = matchRepository.GetMatch(id);

            if (match is null)
            {
                return NotFound();
            }

            return match.AsDto();
        }

        // POST /matches
        [HttpPost]
        public ActionResult<MatchDto> CreateMatch(CreateMatchDto matchDto)
        {
            Match match = new()
            {
                Id = Guid.NewGuid(),
                WinnerId = matchDto.WinnerId,
                LooserId = matchDto.LooserId,
                MatchDate = matchDto.MatchDate
            };
            
            matchRepository.CreateMatch(match);

            var winner = playerRepository.GetPlayer(matchDto.WinnerId);   // To extract all the calculate-points logic outside controller
            var looser = playerRepository.GetPlayer(matchDto.LooserId);

            if( winner is null)
            {
                return NotFound("Winner player does not exist");   

            } else if (looser is null)
            {
                return NotFound("Looser player does not exist");   
            }

            if(winner == looser)
            {
                return BadRequest("looser and winner can not be the same player");
            }

            var points = matchRepository.CalculatePoints(looser.Points); 

            looser.Points = looser.Points - points;
            winner.Points = winner.Points + points;

            looser.Games += 1;
            winner.Games += 1;

            playerRepository.UpdatePlayer(looser);
            playerRepository.UpdatePlayer(winner);

            return CreatedAtAction(nameof(GetMatch), new { id = match.Id}, match.AsDto());
        }

         // PUT /matches/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMatch(Guid id, UpdateMatchDto matchDto)
        {
            var existingMatch = matchRepository.GetMatch(id);

            if (existingMatch is null)
            {
                return NotFound();
            }

            Match updatedMatch = existingMatch with 
            {
                MatchDate = matchDto.MatchDate
            };

            matchRepository.UpdateMatch(updatedMatch);

            return NoContent();
        }

        // DELETE /matches/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMatch(Guid id)
        {
            var existingMatch = matchRepository.GetMatch(id);

            if (existingMatch is null)
            {
                return NotFound();
            }

            matchRepository.DeleteMatch(id);

            return NoContent();
        }
    }
}