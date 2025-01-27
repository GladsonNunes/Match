using Match.Domain.ProjectSkill;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.ProjectSkill
{
    public class RepProjectSkill : IRepProjectSkill
    {
        private readonly AppDbContext _context;

        public RepProjectSkill(AppDbContext context)
        {
            _context = context;
        }
        public List<int> GetProjectAptosBySkill(List<int> dto)
        {
            var projectSkills = _context.ProjectSkill
                .Where(ds => dto.Contains(ds.SkillId)).Select(p => p.ProjectId).Distinct().ToList();

            return projectSkills;
        }
    }
}
