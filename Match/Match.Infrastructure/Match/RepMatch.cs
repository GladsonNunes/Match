using Match.Domain.Match;
using Match.Infrastructure.Core;

namespace Match.Infrastructure.Match
{
    public class RepMatch : RepCore<Domain.Match.Match>, IRepMatch
    {
        public RepMatch(AppDbContext context) : base(context)
        {
        }
    }
}
