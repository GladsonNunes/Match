namespace Match.Domain.Match
{
    public class Match
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
        public double MatchScore { get; set; } // Pontuação de compatibilidade

        public Match(int matchId, int developerId, int projectId, double matchScore)
        {
            Id = matchId;
            DeveloperId = developerId;
            ProjectId = projectId;
            MatchScore = matchScore;
        }
    }
}
