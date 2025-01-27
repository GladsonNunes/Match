using DomainProjectSkill = Match.Domain.ProjectSkill.ProjectSkill;
using System.Text.Json.Serialization;
using Match.Domain.Developer;

namespace Match.Domain.Project
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DeveloperSlots { get; set; }
        public EnumExperienceLevel MinimumExperienceLevel { get; set; }





        public ICollection<DomainProjectSkill>? ProjectSkills { get; set; }

    }
}

