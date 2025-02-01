using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;

namespace Match.Application.Match
{
    public interface IAplicMatch
    {
        DadosMatchDeveloperToProjectDTO MatchDeveloperToProject(int Projectid);
        DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper(int DeveloperId);
        int CreateMatch(CreateMatchDTO dto);
    }
}
