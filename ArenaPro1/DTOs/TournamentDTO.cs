using System;

namespace ArenaPro1.DTOs
{
    public class TournamentDTO
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Game { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}