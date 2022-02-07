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
        private readonly IMatchesRepository repository;

        public MatchesController(IMatchesRepository repository)
        {
            this.repository = repository;
        }

        // GET /matches
        [HttpGet]
        public IEnumerable<MatchDto> GetMatches()
        {
            var matches = repository.GetMatches().Select(match => match.AsDto());
            return matches;
        }

        // GET /macthes/id
        [HttpGet("{id}")]
        public ActionResult<MatchDto> GetMatch(Guid id)
        {
            var match = repository.GetMatch(id);

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
                MatchDate = matchDto.MatchDate
            };
            
        repository.CreateMatch(match);

        return CreatedAtAction(nameof(GetMatch), new { id = match.Id}, match.AsDto());
        }

         // PUT /matches/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMatch(Guid id, UpdateMatchDto matchDto)
        {
            var existingMatch = repository.GetMatch(id);

            if (existingMatch is null)
            {
                return NotFound();
            }

            Match updatedMatch = existingMatch with 
            {
                MatchDate = matchDto.MatchDate
            };

            repository.UpdateMatch(updatedMatch);

            return NoContent();
        }

        // DELETE /matches/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMatch(Guid id)
        {
            var existingMatch = repository.GetMatch(id);

            if (existingMatch is null)
            {
                return NotFound();
            }

            repository.DeleteMatch(id);

            return NoContent();
        }
    }
}