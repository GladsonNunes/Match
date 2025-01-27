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
        private readonly AppDbContext _context;

        public RepDeveloper(AppDbContext context) : base(context)
        {
            _context = context;
        }

        
        public List<DomainDeveloper> GetDevelopersAptos(List<DomainSkill> dto)
        {
            var listDevelopers = new List<DomainDeveloper>();
            var developerSkills =  _context.Developer.Where(d => d.DeveloperSkills.Any(ds => dto.Any(s => s.Id == ds.SkillId))).ToList();
            return listDevelopers;
        }
    }

}
