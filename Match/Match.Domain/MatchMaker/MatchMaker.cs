using Match.Domain.Match;
using System.Text.Json.Serialization;

namespace Match.Domain.MatchMaker
{
    public class MatchMaker
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MatchId { get; set; }
        public EnumStatusProcessedMatchMakers StatusProcessedMatchMaker { get; set; }
        public int DeveloperId { get; set; }
        [JsonIgnore]
        public Match.Match? Match { get; set; }
    }
}
