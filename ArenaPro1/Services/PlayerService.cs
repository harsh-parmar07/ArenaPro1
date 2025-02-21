using ArenaPro1.DTOs;
using ArenaPro1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArenaPro1.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly Data.ApplicationDbContext _context;

        public PlayerService(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlayerDTO>> GetAllPlayersAsync()
        {
            return await _context.Players
                .Select(p => new PlayerDTO { PlayerId = p.PlayerId, Name = p.Name, Email = p.Email })
                .ToListAsync();
        }

        public async Task<PlayerDTO> GetPlayerByIdAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            return player != null ? new PlayerDTO { PlayerId = player.PlayerId, Name = player.Name, Email = player.Email } : null;
        }

        public async Task AddPlayerAsync(PlayerDTO playerDto)
        {
            var player = new Player { Name = playerDto.Name, Email = playerDto.Email };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayerAsync(PlayerDTO playerDto)
        {
            var player = await _context.Players.FindAsync(playerDto.PlayerId);
            if (player != null)
            {
                player.Name = playerDto.Name;
                player.Email = playerDto.Email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}