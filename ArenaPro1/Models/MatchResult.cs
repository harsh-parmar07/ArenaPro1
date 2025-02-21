using System.ComponentModel.DataAnnotations;

namespace ArenaPro1.Models
{
    public class MatchResult
    {
        [Key]
        public int ResultId { get; set; }

        [Required]
        public int TournamentId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int Rank { get; set; }

        // Navigation properties
        public Tournament Tournament { get; set; }
        public Player Player { get; set; }
    }
}