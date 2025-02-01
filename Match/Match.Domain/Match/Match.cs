using System.ComponentModel;

namespace Match.Domain.Match
{
    public class Match
    {
        public int Id { get; set; }
        public EnumStatusProcessed StatusProcessed { get; set; }
        public EnumTypeMatch TypeMatch { get; set; }
        public DateTime DateMatch { get; set; }
        public ICollection<MatchMaker.MatchMaker> MatchMakers { get; set; }

    }

    public enum EnumStatusProcessed
    {
        [Description("WaitingForMatch")]
        WaitingForMatch = 0,

        [Description("MatchAccepted")]
        MatchAccepted = 1,

        [Description("MatchRejected")]
        MatchRejected = 2
    }

    public enum EnumTypeMatch
    {
        [Description("DeveloperToProject")]
        WaitingForMatch = 0,

        [Description("ProjectToDeveloper")]
        MatchAccepted = 1,

    }
}
