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
            var listDevelopers = new List<Developer>();

            
            var listIdsDevelopers = _repDeveloperSkill.GetDevelopersAptosBySkill(dto);

            listDevelopers = _repDeveloper.GetByIds(listIdsDevelopers).ToList();

            return listDevelopers;
        }
    }


}
