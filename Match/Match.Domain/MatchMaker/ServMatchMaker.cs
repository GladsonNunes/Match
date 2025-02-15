using Match.Domain.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Domain.MatchMaker
{
    public class ServMatchMaker: IServMatchMaker
    {
        private readonly IRepMatchMaker _repMatchMaker;
        public ServMatchMaker(IRepMatchMaker repMatchMaker) 
        { 
            _repMatchMaker = repMatchMaker;
        }
        public int ProcessedMatchMaker(int id, EnumStatusProcessedMatchMakers status)
        {
            var matchMaker = _repMatchMaker.GetById(id);
            matchMaker.StatusProcessedMatchMaker = status;
            _repMatchMaker.Update(matchMaker);
            return matchMaker.MatchId;
        }
    }
}
