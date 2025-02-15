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
        [Description("Pending")]
        Pending = 0,

        [Description("Processed")]
        Processed = 1,
    }

    public enum EnumStatusProcessedMatchMakers
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
        DeveloperToProject = 0,

        [Description("ProjectToDeveloper")]
        ProjectToDeveloper = 1,

    }
}
