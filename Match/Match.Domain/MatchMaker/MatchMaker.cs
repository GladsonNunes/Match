using System.Text.Json.Serialization;

namespace Match.Domain.MatchMaker
{
    public class MatchMaker
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MatchId { get; set; }
        public int DeveloperId { get; set; }
        
        public Match.Match Match { get; set; }
    }
}
