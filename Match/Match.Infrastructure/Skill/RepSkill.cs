using Match.Domain.Skill;
using Match.Infrastructure.Core;

namespace Match.Infrastructure.Skill
{
    public class RepSkill : RepCore<Domain.Skill.Skill>, IRepSkill
    {
        public RepSkill(AppDbContext context) : base(context)
        {
        }
    }


}
