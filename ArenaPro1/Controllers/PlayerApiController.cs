using Microsoft.AspNetCore.Mvc;
using ArenaPro1.Services;
using ArenaPro1.DTOs;
using System.Threading.Tasks;

namespace ArenaPro1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersApiController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersApiController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlayerDTO>>> GetPlayers()
        {
            return await _playerService.GetAllPlayersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null) return NotFound();
            return player;
        }

        [HttpPost]
        public async Task<ActionResult> AddPlayer(PlayerDTO playerDto)
        {
            await _playerService.AddPlayerAsync(playerDto);
            return CreatedAtAction(nameof(GetPlayer), new { id = playerDto.PlayerId }, playerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlayer(int id, PlayerDTO playerDto)
        {
            if (id != playerDto.PlayerId) return BadRequest();
            await _playerService.UpdatePlayerAsync(playerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}