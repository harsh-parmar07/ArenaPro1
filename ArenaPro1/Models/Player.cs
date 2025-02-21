using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArenaPro1.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<MatchResult> MatchResults { get; set; } = new List<MatchResult>();
    }
}