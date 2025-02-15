using Match.Domain.MatchMaker;
using Match.Infrastructure.Core;

namespace Match.Infrastructure.MatchMaker
{
    public class RepMatchMaker : RepCore<Domain.MatchMaker.MatchMaker>, IRepMatchMaker
    {
        public RepMatchMaker(AppDbContext context) : base(context)
        {
        }
    }
}
