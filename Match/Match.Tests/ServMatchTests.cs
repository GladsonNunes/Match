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
}
