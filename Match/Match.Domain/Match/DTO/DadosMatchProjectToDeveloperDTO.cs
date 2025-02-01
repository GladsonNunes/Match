namespace Match.Domain.Matches.DTO
{
    public class DadosMatchProjectToDeveloperDTO
    {
        public DadosMatchProjectToDeveloperDTO()
        {
            ProjectsAptos = new List<DadosProjectMatchResultDTO>();
        }
        public List<DadosProjectMatchResultDTO> ProjectsAptos { get; set; }
    }
}
