﻿using DomainProject = Match.Domain.Project.Project;
using Match.Domain.Matches.DTO;
using Match.Domain.Developer;
using static System.Formats.Asn1.AsnWriter;
using Match.Domain.Project;
using Match.Domain.Match.DTO;
using Match.Domain.MatchNotification;

namespace Match.Domain.Match
{
    public class ServMatch : IServMatch
    {
        private readonly IServDeveloper _servDeveloper;
        private readonly IServProject _servProject;
        private readonly IRepMatch _repMatch;
        private readonly IServMatchNotification _servMatchNotification;

        public ServMatch(IServDeveloper servDeveloper,IServProject servProject, IRepMatch repMatch, IServMatchNotification servMatchNotification)
        {
            _servDeveloper = servDeveloper;
            _servProject = servProject;
            _repMatch = repMatch;
            _servMatchNotification = servMatchNotification;
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

        public DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper(int developerId)
        {
            var matchProjectToDeveloper = new DadosMatchProjectToDeveloperDTO();
            var developer = _servDeveloper.GetDeveloperById(developerId);
            var requiredExperienceLevel = developer.ExperienceLevel;
            var requiredSkills = developer.DeveloperSkills.Select(s => s.SkillId).ToList();
            var projectsAptos = _servProject.GetProjectAptosBySkill(requiredSkills);

            foreach (var project in projectsAptos)
            {
                var projectSkills = project.ProjectSkills.Select(ds => ds.SkillId).ToList();
                var skillMatchCount = requiredSkills.Count(rs => projectSkills.Contains(rs));
                var experienceMatch = project.MinimumExperienceLevel <= requiredExperienceLevel;

                if (skillMatchCount > 0 && experienceMatch)
                {
                    var score = skillMatchCount * 10 + (experienceMatch ? 20 : 0);

                    matchProjectToDeveloper.ProjectsAptos.Add(new DadosProjectMatchResultDTO
                    {
                        Project = new DomainProject
                        {
                            Id = project.Id,
                            Name = project.Name,
                            Description = project.Description,
                            MinimumExperienceLevel = project.MinimumExperienceLevel
                        },
                        Score = score
                    });
                }
            }

            return matchProjectToDeveloper;
        }

        public int CreateMatch(CreateMatchDTO dto)
        {
            var match = new Match
            {
                Id = dto.Match.Id,
                StatusProcessed = dto.Match.StatusProcessed,
                TypeMatch = dto.Match.TypeMatch,
                DateMatch = dto.Match.DateMatch,
                MatchMakers = new List<MatchMaker.MatchMaker>()
            };

            // Converter e associar MatchMakers
            foreach (var matchMakerDto in dto.Match.MatchMakers)
            {
                var matchMaker = new MatchMaker.MatchMaker
                {
                    Id = matchMakerDto.Id,
                    ProjectId = matchMakerDto.ProjectId,
                    DeveloperId = matchMakerDto.DeveloperId,
                    MatchId = dto.Match.Id,
                };

                match.MatchMakers.Add(matchMaker);
            }

            _repMatch.Add(match);

            if (dto.Match.TypeMatch == EnumTypeMatch.ProjectToDeveloper) 
            {
                var developer = dto.DevelopersId.Distinct().FirstOrDefault();
                _servMatchNotification.NotificationProject(dto.Project.ProjectId, developer.DeveloperId);
            }
            else
            {
                _servMatchNotification.NotificationDeveloper(dto.DevelopersId, dto.Project.ProjectId);
            }
            
            return 1;
        }

    }
}

