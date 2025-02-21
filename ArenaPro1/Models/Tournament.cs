using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArenaPro1.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Game { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<MatchResult> MatchResults { get; set; } = new List<MatchResult>();
    }
}