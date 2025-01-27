using System.Text.Json.Serialization;
using DomainProject = Match.Domain.Project.Project;
using DomainSkill = Match.Domain.Skill.Skill;
namespace Match.Domain.ProjectSkill
{
    public class ProjectSkill
    {
        public int ProjectId { get; set; }
        [JsonIgnore]
        public DomainProject? Project { get; set; }

        public int SkillId { get; set; }
        [JsonIgnore]
        public DomainSkill? Skill { get; set; }

    }
}
