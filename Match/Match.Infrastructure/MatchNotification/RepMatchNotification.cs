using Match.Domain.MatchNotification;
using Match.Infrastructure.Core;

namespace Match.Infrastructure.MatchNotification
{
    public class RepMatchNotification : RepCore<Domain.MatchNotification.MatchNotification>, IRepMatchNotification
    {
        public RepMatchNotification(AppDbContext context) : base(context)
        {
        }
    }
}
