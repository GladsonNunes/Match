using DomainSkill = Match.Domain.Skill.Skill;
namespace Match.Domain.Developer
{
    public interface IServDeveloper
    {
        List<Developer> GetDevelopersAptosBySkill(List<int> dto);
    }
}
