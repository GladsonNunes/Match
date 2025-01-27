using Match.Domain.DeveloperSkill;

namespace Match.Infrastructure.DeveloperSkill
{
    public class RepDeveloperSkill : IRepDeveloperSkill
    {
        private readonly AppDbContext _context;

        public RepDeveloperSkill(AppDbContext context)
        {
            _context = context;
        }
        public List<int> GetDevelopersAptosBySkill(List<int> dto)
        {
            var developerSkills = _context.DeveloperSkill
                .Where(ds => dto.Contains(ds.SkillId)).Select(p=> p.DeveloperId).Distinct().ToList();

            return developerSkills;
        }
    }
}
