using ArenaPro1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArenaPro1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Players
        public DbSet<Player> Players { get; set; }

        // DbSet for Tournaments
        public DbSet<Tournament> Tournaments { get; set; }

        // DbSet for MatchResults
        public DbSet<MatchResult> MatchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Players and Tournaments via MatchResults
            modelBuilder.Entity<MatchResult>()
                .HasOne(mr => mr.Player)
                .WithMany(p => p.MatchResults)
                .HasForeignKey(mr => mr.PlayerId);

            modelBuilder.Entity<MatchResult>()
                .HasOne(mr => mr.Tournament)
                .WithMany(t => t.MatchResults)
                .HasForeignKey(mr => mr.TournamentId);
        }
    }
}