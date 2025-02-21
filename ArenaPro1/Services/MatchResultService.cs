using ArenaPro1.Data;
using ArenaPro1.DTOs;
using ArenaPro1.Models;
using Microsoft.EntityFrameworkCore;


namespace ArenaPro1.Services
{
    public class MatchResultService : IMatchResultService
    {
        private readonly ApplicationDbContext _context;

        public MatchResultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MatchResultDTO>> GetAllMatchResultsAsync()
        {
            return await _context.MatchResults
                .Include(mr => mr.Tournament)
                .Include(mr => mr.Player)
                .Select(mr => new MatchResultDTO
                {
                    ResultId = mr.ResultId,
                    TournamentId = mr.TournamentId,
                    PlayerId = mr.PlayerId,
                    Score = mr.Score,
                    Rank = mr.Rank,
                    TournamentName = mr.Tournament.Name,
                    PlayerName = mr.Player.Name
                })
                .ToListAsync();
        }

        public async Task<MatchResultDTO> GetMatchResultByIdAsync(int id)
        {
            var matchResult = await _context.MatchResults
                .Include(mr => mr.Tournament)
                .Include(mr => mr.Player)
                .FirstOrDefaultAsync(mr => mr.ResultId == id);

            return matchResult != null ? new MatchResultDTO
            {
                ResultId = matchResult.ResultId,
                TournamentId = matchResult.TournamentId,
                PlayerId = matchResult.PlayerId,
                Score = matchResult.Score,
                Rank = matchResult.Rank,
                TournamentName = matchResult.Tournament.Name,
                PlayerName = matchResult.Player.Name
            } : null;
        }

        public async Task AddMatchResultAsync(MatchResultDTO matchResultDto)
        {
            var matchResult = new MatchResult
            {
                TournamentId = matchResultDto.TournamentId,
                PlayerId = matchResultDto.PlayerId,
                Score = matchResultDto.Score,
                Rank = matchResultDto.Rank
            };
            _context.MatchResults.Add(matchResult);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMatchResultAsync(MatchResultDTO matchResultDto)
        {
            var matchResult = await _context.MatchResults.FindAsync(matchResultDto.ResultId);
            if (matchResult != null)
            {
                matchResult.TournamentId = matchResultDto.TournamentId;
                matchResult.PlayerId = matchResultDto.PlayerId;
                matchResult.Score = matchResultDto.Score;
                matchResult.Rank = matchResultDto.Rank;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMatchResultAsync(int id)
        {
            var matchResult = await _context.MatchResults.FindAsync(id);
            if (matchResult != null)
            {
                _context.MatchResults.Remove(matchResult);
                await _context.SaveChangesAsync();
            }
        }
    }
}