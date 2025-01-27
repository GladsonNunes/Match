using Match.Domain.Developer;
using Match.Domain.Match;
using Match.Domain.Project;
using Moq;

namespace Match.Tests;

public class ServMatchTests
{
    private readonly Mock<IServDeveloper> _mockServDeveloper;
    private readonly Mock<IServProject> _mockServProject;
    private readonly ServMatch _servMatch;

    public ServMatchTests()
    {
        _mockServDeveloper = new Mock<IServDeveloper>();
        _mockServProject = new Mock<IServProject>();
        _servMatch = new ServMatch(_mockServDeveloper.Object, _mockServProject.Object);
    }

    [Fact]
    public void MatchDeveloperToProject_ShouldReturnMatchedDevelopers()
    {
        // Arrange
        var projectId = 1;
        var project = new Project
        {
            Id = projectId,
            MinimumExperienceLevel = EnumExperienceLevel.Pleno,
            DeveloperSlots = 2,
            ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
            {
                new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
                new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
            }
        };

        var developers = new List<Developer>
        {
            new Developer
            {
                Id = 1,
                Name = "Dev1",
                Email = "dev1@example.com",
                ExperienceLevel = EnumExperienceLevel.Pleno,
                DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
                {
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
                }
            },
            new Developer
            {
                Id = 2,
                Name = "Dev2",
                Email = "dev2@example.com",
                ExperienceLevel = EnumExperienceLevel.Senior,
                DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
                {
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 }
                }
            }
        };

        _mockServProject.Setup(s => s.GetProjectById(projectId)).Returns(project);
        _mockServDeveloper.Setup(s => s.GetDevelopersAptosBySkill(It.IsAny<List<int>>())).Returns(developers);

        // Act
        var result = _servMatch.MatchDeveloperToProject(projectId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.DevelopersAptos.Count);
        Assert.Equal(0, result.DevelopersAptosSegunda.Count);
    }
    [Fact]
    public void MatchDeveloperToProject_ShouldReturnNoMatchedDevelopers_WhenNoDevelopersMatchSkills()
    {
        // Arrange
        var projectId = 2;
        var project = new Project
        {
            Id = projectId,
            MinimumExperienceLevel = EnumExperienceLevel.Pleno,
            DeveloperSlots = 2,
            ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
        {
            new Domain.ProjectSkill.ProjectSkill { SkillId = 3 },
            new Domain.ProjectSkill.ProjectSkill { SkillId = 4 }
        }
        };

        var developers = new List<Developer>();

        _mockServProject.Setup(s => s.GetProjectById(projectId)).Returns(project);
        _mockServDeveloper.Setup(s => s.GetDevelopersAptosBySkill(It.IsAny<List<int>>())).Returns(developers);

        // Act
        var result = _servMatch.MatchDeveloperToProject(projectId);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result.DevelopersAptos);
        Assert.Empty(result.DevelopersAptosSegunda);
    }

    [Fact]
    public void MatchDeveloperToProject_ShouldReturnMatchedDevelopers_WhenExperienceLevelIsLower()
    {
        // Arrange
        var projectId = 3;
        var project = new Project
        {
            Id = projectId,
            MinimumExperienceLevel = EnumExperienceLevel.Senior,
            DeveloperSlots = 2,
            ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
        {
            new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
            new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
        }
        };

        var developers = new List<Developer>
    {
        new Developer
        {
            Id = 1,
            Name = "Dev1",
            Email = "dev1@example.com",
            ExperienceLevel = EnumExperienceLevel.Pleno,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
            {
                new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
            }
        }
    };

        _mockServProject.Setup(s => s.GetProjectById(projectId)).Returns(project);
        _mockServDeveloper.Setup(s => s.GetDevelopersAptosBySkill(It.IsAny<List<int>>())).Returns(developers);

        // Act
        var result = _servMatch.MatchDeveloperToProject(projectId);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result.DevelopersAptos);
        Assert.Empty(result.DevelopersAptosSegunda);
    }

    [Fact]
    public void MatchDeveloperToProject_ShouldReturnMatchedDevelopers_WhenMultipleDevelopersMatch()
    {
        // Arrange
        var projectId = 4;
        var project = new Project
        {
            Id = projectId,
            MinimumExperienceLevel = EnumExperienceLevel.Junior,
            DeveloperSlots = 2,
            ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
        {
            new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
            new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
        }
        };

        var developers = new List<Developer>
    {
        new Developer
        {
            Id = 1,
            Name = "Dev1",
            Email = "dev1@example.com",
            ExperienceLevel = EnumExperienceLevel.Junior,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
            {
                new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
            }
        },
        new Developer
        {
            Id = 2,
            Name = "Dev2",
            Email = "dev2@example.com",
            ExperienceLevel = EnumExperienceLevel.Junior,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
            {
                new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
            }
        }
    };

        _mockServProject.Setup(s => s.GetProjectById(projectId)).Returns(project);
        _mockServDeveloper.Setup(s => s.GetDevelopersAptosBySkill(It.IsAny<List<int>>())).Returns(developers);

        // Act
        var result = _servMatch.MatchDeveloperToProject(projectId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.DevelopersAptos.Count);
        Assert.Empty(result.DevelopersAptosSegunda);
    }

    [Fact]
    public void MatchProjectToDeveloper_ShouldReturnMatchedProjects()
    {
        // Arrange
        var developerId = 1;
        var developer = new Developer
        {
            Id = developerId,
            ExperienceLevel = EnumExperienceLevel.Pleno,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
                {
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
                }
        };

        var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    MinimumExperienceLevel = EnumExperienceLevel.Pleno,
                    ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
                    {
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
                    }
                },
                new Project
                {
                    Id = 2,
                    MinimumExperienceLevel = EnumExperienceLevel.Junior,
                    ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
                    {
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 1 }
                    }
                }
            };

        _mockServDeveloper.Setup(s => s.GetDeveloperById(developerId)).Returns(developer);
        _mockServProject.Setup(s => s.GetProjectAptosBySkill(It.IsAny<List<int>>())).Returns(projects);

        // Act
        var result = _servMatch.MatchProjectToDeveloper(developerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.ProjectsAptos.Count);
    }

    [Fact]
    public void MatchProjectToDeveloper_ShouldReturnNoMatchedProjects_WhenNoProjectsMatchSkills()
    {
        // Arrange
        var developerId = 2;
        var developer = new Developer
        {
            Id = developerId,
            ExperienceLevel = EnumExperienceLevel.Pleno,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
                {
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 3 },
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 4 }
                }
        };

        var projects = new List<Project>();

        _mockServDeveloper.Setup(s => s.GetDeveloperById(developerId)).Returns(developer);
        _mockServProject.Setup(s => s.GetProjectAptosBySkill(It.IsAny<List<int>>())).Returns(projects);

        // Act
        var result = _servMatch.MatchProjectToDeveloper(developerId);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result.ProjectsAptos);
    }

    [Fact]
    public void MatchProjectToDeveloper_ShouldReturnMatchedProjects_WhenExperienceLevelIsLower()
    {
        // Arrange
        var developerId = 3;
        var developer = new Developer
        {
            Id = developerId,
            ExperienceLevel = EnumExperienceLevel.Senior,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
                {
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
                }
        };

        var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    MinimumExperienceLevel = EnumExperienceLevel.Pleno,
                    ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
                    {
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
                    }
                }
            };

        _mockServDeveloper.Setup(s => s.GetDeveloperById(developerId)).Returns(developer);
        _mockServProject.Setup(s => s.GetProjectAptosBySkill(It.IsAny<List<int>>())).Returns(projects);

        // Act
        var result = _servMatch.MatchProjectToDeveloper(developerId);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.ProjectsAptos);
    }

    [Fact]
    public void MatchProjectToDeveloper_ShouldReturnMatchedProjects_WhenMultipleProjectsMatch()
    {
        // Arrange
        var developerId = 4;
        var developer = new Developer
        {
            Id = developerId,
            ExperienceLevel = EnumExperienceLevel.Junior,
            DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill>
                {
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 },
                    new Domain.DeveloperSkill.DeveloperSkill { SkillId = 2 }
                }
        };

        var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    MinimumExperienceLevel = EnumExperienceLevel.Junior,
                    ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
                    {
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
                    }
                },
                new Project
                {
                    Id = 2,
                    MinimumExperienceLevel = EnumExperienceLevel.Junior,
                    ProjectSkills = new List<Domain.ProjectSkill.ProjectSkill>
                    {
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 1 },
                        new Domain.ProjectSkill.ProjectSkill { SkillId = 2 }
                    }
                }
            };

        _mockServDeveloper.Setup(s => s.GetDeveloperById(developerId)).Returns(developer);
        _mockServProject.Setup(s => s.GetProjectAptosBySkill(It.IsAny<List<int>>())).Returns(projects);

        // Act
        var result = _servMatch.MatchProjectToDeveloper(developerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.ProjectsAptos.Count);
    }
}
