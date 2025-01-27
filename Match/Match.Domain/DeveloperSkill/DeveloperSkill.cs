using System.Text.Json.Serialization;
using DomainDeveloper = Match.Domain.Developer.Developer;
using DomainSkill = Match.Domain.Skill.Skill;


namespace Match.Domain.DeveloperSkill
{
    public class DeveloperSkill
    {
        public int DeveloperId { get; set; }
        [JsonIgnore]
        public DomainDeveloper? Developer { get; set; }

        public int SkillId { get; set; }

        [JsonIgnore]
        public DomainSkill? Skill { get; set; }
        

    }
}
