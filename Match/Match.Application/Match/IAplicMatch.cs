using Match.Domain.Match;
using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;

namespace Match.Application.Match
{
    public interface IAplicMatch
    {
        DadosMatchDeveloperToProjectDTO MatchDeveloperToProject(int Projectid);
        DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper(int DeveloperId);
        void CreateMatch(CreateMatchDTO dto);
        Domain.Match.Match GetMatchById(int Id);
    }
}
