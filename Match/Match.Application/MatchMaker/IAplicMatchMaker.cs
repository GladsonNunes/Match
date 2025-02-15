using Match.Domain.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Application.MatchMaker
{
    public interface IAplicMatchMaker
    {
        void ProcessedMatchMaker(int id, EnumStatusProcessedMatchMakers status);
    }
}
