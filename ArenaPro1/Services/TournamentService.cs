using ArenaPro1.DTOs;
using ArenaPro1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaPro1.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly Data.ApplicationDbContext _context;

        public TournamentService(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TournamentDTO>> GetAllTournamentsAsync()
        {
            return await _context.Tournaments
                .Select(t => new TournamentDTO
                {
                    TournamentId = t.TournamentId,
                    Name = t.Name,
                    Game = t.Game,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate
                })
                .ToListAsync();
        }

        public async Task<TournamentDTO> GetTournamentByIdAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            return tournament != null ? new TournamentDTO
            {
                TournamentId = tournament.TournamentId,
                Name = tournament.Name,
                Game = tournament.Game,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate
            } : null;
        }

        public async Task AddTournamentAsync(TournamentDTO tournamentDto)
        {
            var tournament = new Tournament
            {
                Name = tournamentDto.Name,
                Game = tournamentDto.Game,
                StartDate = tournamentDto.StartDate,
                EndDate = tournamentDto.EndDate
            };
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTournamentAsync(TournamentDTO tournamentDto)
        {
            var tournament = await _context.Tournaments.FindAsync(tournamentDto.TournamentId);
            if (tournament != null)
            {
                tournament.Name = tournamentDto.Name;
                tournament.Game = tournamentDto.Game;
                tournament.StartDate = tournamentDto.StartDate;
                tournament.EndDate = tournamentDto.EndDate;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTournamentAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();
            }
        }
    }
}