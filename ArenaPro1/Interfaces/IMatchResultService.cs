using ArenaPro1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArenaPro1.Services
{
    public interface IMatchResultService
    {
        Task<List<MatchResultDTO>> GetAllMatchResultsAsync();
        Task<MatchResultDTO> GetMatchResultByIdAsync(int id);
        Task AddMatchResultAsync(MatchResultDTO matchResultDto);
        Task UpdateMatchResultAsync(MatchResultDTO matchResultDto);
        Task DeleteMatchResultAsync(int id);
    }
}