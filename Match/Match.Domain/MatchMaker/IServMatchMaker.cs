using Match.Domain.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Domain.MatchMaker
{
    public interface IServMatchMaker
    {
        int ProcessedMatchMaker(int id, EnumStatusProcessedMatchMakers status);
    }
}
