using Match.Domain.DeveloperSkill;
using DomainSkill = Match.Domain.Skill.Skill;
namespace Match.Domain.Developer
{
    public class ServDeveloper : IServDeveloper
    {
        private readonly IRepDeveloper _repDeveloper;
        private readonly IRepDeveloperSkill _repDeveloperSkill;
        public ServDeveloper(IRepDeveloper repDeveloper,IRepDeveloperSkill repDeveloperSkill)
        {
            _repDeveloper = repDeveloper;
            _repDeveloperSkill = repDeveloperSkill;
        }
        public List<Developer> GetDevelopersAptosBySkill(List<int> dto)
        {
            var listIdsDevelopers = _repDeveloperSkill.GetDevelopersAptosBySkill(dto);
            return _repDeveloper.GetByIds(listIdsDevelopers).ToList();
        }

        public Developer GetDeveloperById(int developerId)
        {
            return _repDeveloper.GetById(developerId);
        }
    }


}
