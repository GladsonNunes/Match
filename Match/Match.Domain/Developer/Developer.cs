using DomainDeveloperSkill = Match.Domain.DeveloperSkill.DeveloperSkill;
using System.ComponentModel;

namespace Match.Domain.Developer
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EnumExperienceLevel ExperienceLevel { get; set; }
        public ICollection<DomainDeveloperSkill>? DeveloperSkills { get; set; }
    }

    public enum EnumExperienceLevel
    {
        [Description("Junior")]
        Junior = 0,

        [Description("Pleno")]
        Pleno = 1,

        [Description("Senior")]
        Senior = 2
    }
}
