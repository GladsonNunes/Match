using Match.Application.MatchMaker;
using Match.Domain.Match;
using Match.Domain.MatchMaker;

namespace Match.Application
{
    public class AplicMatchMaker : IAplicMatchMaker
    {
        private readonly IServMatchMaker _servMatchMaker;
        private readonly IServMatch _servMatch;
        
        public AplicMatchMaker(IServMatchMaker servMatchMaker,IServMatch servMatch) 
        { 
            _servMatchMaker = servMatchMaker;
            _servMatch = servMatch;
        }
        public void ProcessedMatchMaker(int id, EnumStatusProcessedMatchMakers status)
        {
            var matchId = _servMatchMaker.ProcessedMatchMaker(id, status);
            _servMatch.UpdateStatus(matchId);
        }
    }
}
