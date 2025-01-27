using Match.Domain.Matches.DTO;

namespace Match.Domain.Match
{
    public interface IServMatch
    {
        DadosMatchDeveloperToProjectDTO MatchDeveloperToProject(int projectId);
        DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper(int developerId);
    }
}
