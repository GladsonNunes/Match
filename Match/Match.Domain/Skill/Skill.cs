using System.Text.Json.Serialization;
using DomainDeveloperSkill = Match.Domain.DeveloperSkill.DeveloperSkill;
using DomainProjectSkill = Match.Domain.ProjectSkill.ProjectSkill;
namespace Match.Domain.Skill
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public ICollection<DomainDeveloperSkill>? DeveloperSkills { get; set; }
        
        [JsonIgnore]
        public ICollection<DomainProjectSkill>? ProjectSkills { get; set; }
    }
}
