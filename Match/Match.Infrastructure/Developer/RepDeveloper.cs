using Match.Domain.Core;
using Match.Domain.Developer;
using Match.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using DomainDeveloper = Match.Domain.Developer.Developer;
using DomainSkill = Match.Domain.Skill.Skill;

namespace Match.Infrastructure.Developer
{
    public class RepDeveloper : RepCore<DomainDeveloper>, IRepDeveloper
    {
        public RepDeveloper(AppDbContext context) : base(context)
        {
        }

        
        
    }

}
