using Microsoft.AspNetCore.Mvc;
using ArenaPro1.Services;
using ArenaPro1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArenaPro1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsApiController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentsApiController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TournamentDTO>>> GetTournaments()
        {
            return await _tournamentService.GetAllTournamentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDTO>> GetTournament(int id)
        {
            var tournament = await _tournamentService.GetTournamentByIdAsync(id);
            if (tournament == null) return NotFound();
            return tournament;
        }

        [HttpPost]
        public async Task<ActionResult> AddTournament(TournamentDTO tournamentDto)
        {
            await _tournamentService.AddTournamentAsync(tournamentDto);
            return CreatedAtAction(nameof(GetTournament), new { id = tournamentDto.TournamentId }, tournamentDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTournament(int id, TournamentDTO tournamentDto)
        {
            if (id != tournamentDto.TournamentId) return BadRequest();
            await _tournamentService.UpdateTournamentAsync(tournamentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTournament(int id)
        {
            await _tournamentService.DeleteTournamentAsync(id);
            return NoContent();
        }
    }
}