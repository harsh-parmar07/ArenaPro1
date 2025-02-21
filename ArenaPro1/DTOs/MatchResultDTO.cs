namespace ArenaPro1.DTOs
{
    public class MatchResultDTO
    {
        internal string? PlayerName;

        public int ResultId { get; set; }
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
        public string? TournamentName { get; internal set; }
    }
}