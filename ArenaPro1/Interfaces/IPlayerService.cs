using System.Collections.Generic;
using System.Threading.Tasks;
using ArenaPro1.DTOs;

namespace ArenaPro1.Services
{
    public interface IPlayerService
    {
        Task<List<PlayerDTO>> GetAllPlayersAsync();
        Task<PlayerDTO> GetPlayerByIdAsync(int id);
        Task AddPlayerAsync(PlayerDTO playerDto);
        Task UpdatePlayerAsync(PlayerDTO playerDto);
        Task DeletePlayerAsync(int id);
    }
}