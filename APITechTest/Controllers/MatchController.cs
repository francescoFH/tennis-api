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
    }
}