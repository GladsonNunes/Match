namespace Match.Domain.Match.DTO
{
    public class CreateMatchDTO
    {
        public MatchDTO Match { get; set; }
        public List<DeveloperIdDTO> DevelopersId { get; set; }
        public ProjectIdDTO Project { get; set; }

    }

    public class DeveloperIdDTO
    {
        public int DeveloperId { get; set; }
    }

    public class ProjectIdDTO
    {
        public int ProjectId { get; set; }
    }

   public class MatchDTO
   {
        public int Id { get; set; }
        public EnumTypeMatch TypeMatch { get; set; }
        public DateTime DateMatch { get; set; }
        public List<MatchMakerDTO> MatchMakers { get; set; }
    }

    public class MatchMakerDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MatchId { get; set; }
        public int DeveloperId { get; set; }
    }
}
