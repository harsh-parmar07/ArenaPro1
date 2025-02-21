using Microsoft.AspNetCore.Mvc;
using ArenaPro1.Services;
using ArenaPro1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArenaPro1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchResultsApiController : ControllerBase
    {
        private readonly IMatchResultService _matchResultService;

        public MatchResultsApiController(IMatchResultService matchResultService)
        {
            _matchResultService = matchResultService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MatchResultDTO>>> GetMatchResults()
        {
            return await _matchResultService.GetAllMatchResultsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchResultDTO>> GetMatchResult(int id)
        {
            var matchResult = await _matchResultService.GetMatchResultByIdAsync(id);
            if (matchResult == null) return NotFound();
            return matchResult;
        }

        [HttpPost]
        public async Task<ActionResult> AddMatchResult(MatchResultDTO matchResultDto)
        {
            await _matchResultService.AddMatchResultAsync(matchResultDto);
            return CreatedAtAction(nameof(GetMatchResult), new { id = matchResultDto.ResultId }, matchResultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMatchResult(int id, MatchResultDTO matchResultDto)
        {
            if (id != matchResultDto.ResultId) return BadRequest();
            await _matchResultService.UpdateMatchResultAsync(matchResultDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatchResult(int id)
        {
            await _matchResultService.DeleteMatchResultAsync(id);
            return NoContent();
        }
    }
}