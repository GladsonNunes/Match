using Match.Api.Controllers.Core;
using DomainSkill = Match.Domain.Skill.Skill;

namespace Match.Api.Controllers.Skill
{
    public class SkillController : CoreController<DomainSkill>
    {
        public SkillController(Domain.Core.IServCore<DomainSkill> service) : base(service)
        {
        }
    }
}
