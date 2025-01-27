namespace Match.Domain.Matches.DTO
{
    public class DadosMatchProjectToDeveloperDTO
    {
        public DadosMatchProjectToDeveloperDTO()
        {
            ProjectsAptos = new List<DadosDeveloperMatchResultDTO>();
            ProjectsAptosSecond = new List<DadosDeveloperMatchResultDTO>();
        }
        public List<DadosDeveloperMatchResultDTO> ProjectsAptos { get; set; }
        public List<DadosDeveloperMatchResultDTO> ProjectsAptosSecond { get; set; }
    }
}
