using ArenaPro1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArenaPro1.Services
{
    public interface ITournamentService
    {
        Task<List<TournamentDTO>> GetAllTournamentsAsync();
        Task<TournamentDTO> GetTournamentByIdAsync(int id);
        Task AddTournamentAsync(TournamentDTO tournamentDto);
        Task UpdateTournamentAsync(TournamentDTO tournamentDto);
        Task DeleteTournamentAsync(int id);
    }
}