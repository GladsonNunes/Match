namespace Match.Domain.Match.DTO
{
    public class CreateMatchDTO
    {
        public Match Match { get; set; }
        public List<Developer.Developer> Developers { get; set; }
        public Project.Project Project { get; set; }

    }
}
