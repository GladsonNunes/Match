using DomainProject = Match.Domain.Project.Project;
using Match.Domain.Matches.DTO;
using Match.Domain.Developer;
using static System.Formats.Asn1.AsnWriter;
using Match.Domain.Project;

namespace Match.Domain.Match
{
    public class ServMatch : IServMatch
    {
        private readonly IServDeveloper _servDeveloper;
        private readonly IServProject _servProject;

        public ServMatch(IServDeveloper servDeveloper,IServProject servProject)
        {
            _servDeveloper = servDeveloper;
            _servProject = servProject;
        }

        public DadosMatchDeveloperToProjectDTO MatchDeveloperToProject(int projectId)
        {
            var matchedDevelopers = new DadosMatchDeveloperToProjectDTO();
            var developerAptos = new List<DadosDeveloperMatchResultDTO>();
            var project = _servProject.GetProjectById(projectId);

            var requiredExperienceLevel = project.MinimumExperienceLevel;

            var requiredSkills = project.ProjectSkills.Select(s => s.SkillId).ToList();
            

            var developersAptos = _servDeveloper.GetDevelopersAptosBySkill(requiredSkills);
            var devSlots = 0;
            foreach (var developer in developersAptos)
            {
                var developerSkills = developer.DeveloperSkills.Select(ds => ds.SkillId).ToList();
                var skillMatchCount = requiredSkills.Count(rs => developerSkills.Contains(rs));

                var experienceMatch = developer.ExperienceLevel >= requiredExperienceLevel;

                if (skillMatchCount > 0 && experienceMatch)
                {
                    var score = skillMatchCount * 10 + (experienceMatch ? 20 : 0);


                    developerAptos.Add(new DadosDeveloperMatchResultDTO
                    {
                        Developer = new Developer.Developer
                        {
                            Id = developer.Id,
                            Name = developer.Name,
                            Email = developer.Email,
                            ExperienceLevel = developer.ExperienceLevel
                        },
                        Score = score
                    });
                }
            }
            foreach (var item in developerAptos.OrderByDescending(p => p.Score).ToList())
            {
                devSlots += 1;
                if (project.DeveloperSlots >= devSlots)
                {
                    matchedDevelopers.DevelopersAptos.Add(new DadosDeveloperMatchResultDTO
                    {
                        Developer = new Developer.Developer
                        {
                            Id = item.Developer.Id,
                            Name = item.Developer.Name,
                            Email = item.Developer.Email,
                            ExperienceLevel = item.Developer.ExperienceLevel
                        },
                        Score = item.Score
                    });
                }
                else
                {
                    if (project.DeveloperSlots * 2 >= devSlots)
                    {
                        matchedDevelopers.DevelopersAptosSegunda.Add(new DadosDeveloperMatchResultDTO
                        {
                            Developer = new Developer.Developer
                            {
                                Id = item.Developer.Id,
                                Name = item.Developer.Name,
                                Email = item.Developer.Email,
                                ExperienceLevel = item.Developer.ExperienceLevel
                            },
                            Score = item.Score
                        });
                    }

                }
            }
            
            matchedDevelopers.DevelopersAptos = matchedDevelopers.DevelopersAptos.OrderByDescending(d => d.Score).ToList();
            matchedDevelopers.DevelopersAptosSegunda = matchedDevelopers.DevelopersAptosSegunda.OrderByDescending(d => d.Score).ToList();
            
            return matchedDevelopers;
        }

        public DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper (int developerId)
        {
            var matchProjectToDeveloper = new DadosMatchProjectToDeveloperDTO();
            return matchProjectToDeveloper;
        }

    }
}

