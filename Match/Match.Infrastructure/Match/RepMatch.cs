using Match.Infrastructure.Core;

namespace Match.Infrastructure.Match
{
    public class RepMatch : RepCore<Domain.Match.Match>
    {
        public RepMatch(AppDbContext context) : base(context)
        {
        }
    }
}
