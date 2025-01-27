using DomainDeveloper = Match.Domain.Developer.Developer;
namespace Match.Domain.Matches.DTO
{
    public class DadosMatchDeveloperToProjectDTO
    {
        public DadosMatchDeveloperToProjectDTO()
        {
            DevelopersAptos = new List<DadosDeveloperMatchResultDTO>();
            DevelopersAptosSegunda = new List<DadosDeveloperMatchResultDTO>();
        }
        public List<DadosDeveloperMatchResultDTO> DevelopersAptos { get; set; }
        public List<DadosDeveloperMatchResultDTO> DevelopersAptosSegunda { get; set; }
    }
}
