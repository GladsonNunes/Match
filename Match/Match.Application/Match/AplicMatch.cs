using Match.Domain.Developer;
using Match.Domain.Match;
using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;

namespace Match.Application.Match
{
    public class AplicMatch : IAplicMatch
    {
        private readonly IServMatch _servMatch;
        public AplicMatch(IServMatch servMatch) 
        {
            _servMatch = servMatch;
        }
        public DadosMatchDeveloperToProjectDTO MatchDeveloperToProject(int Projectid)
        {
            return _servMatch.MatchDeveloperToProject(Projectid);
        }

        public DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper(int DeveloperId)
        {
            return _servMatch.MatchProjectToDeveloper(DeveloperId);
        }

        public int CreateMatch(CreateMatchDTO dto) 
        {
            return _servMatch.CreateMatch(dto);
        }
    }
}
