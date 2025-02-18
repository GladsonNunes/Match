using Match.Domain.Developer;
using Match.Domain.Match;
using Match.Domain.MatchMaker;
using Match.Domain.MatchNotification;
using Match.Domain.Project;
using Match.Domain.ProjectSkill;
using Moq;

namespace Match.Tests.MatchTest
{
    public class ServMatchTest
    {
        private readonly Mock<IServDeveloper> _mockServDeveloper;
        private readonly Mock<IServProject> _mockServProject;
        private readonly Mock<IRepMatch> _mockRepMatch;
        private readonly Mock<IRepMatchMaker> _mockRepMatchMaker;
        private readonly Mock<IServMatchNotification> _mockServMatchNotification;
        private readonly ServMatch _servMatch;

        public ServMatchTest()
        {
            _mockServDeveloper = new Mock<IServDeveloper>();
            _mockServProject = new Mock<IServProject>();
            _mockRepMatch = new Mock<IRepMatch>();
            _mockRepMatchMaker = new Mock<IRepMatchMaker>();
            _mockServMatchNotification = new Mock<IServMatchNotification>();

            _servMatch = new ServMatch(
                _mockServDeveloper.Object,
                _mockServProject.Object,
                _mockRepMatch.Object,
                _mockServMatchNotification.Object,
                _mockRepMatchMaker.Object
            );
        }

        [Fact]
        public void MatchDeveloperToProjectShouldReturnMatchedDevelopers()
        {
            // Arrange
            var projectId = 1;
            var project = new Project
            {
                Id = projectId,
                MinimumExperienceLevel = EnumExperienceLevel.Junior,
                DeveloperSlots = 2,
                ProjectSkills = new List<ProjectSkill> { new ProjectSkill { SkillId = 1 } }
            };
            var developers = new List<Developer>
                {
                    new Developer
                    {
                        Id = 1,
                        Name = "Dev1",
                        Email = "dev1@example.com",
                        ExperienceLevel =  EnumExperienceLevel.Senior,
                        DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill> { new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 } }
                    }
                };

            _mockServProject.Setup(s => s.GetProjectById(projectId)).Returns(project);
            _mockServDeveloper.Setup(s => s.GetDevelopersAptosBySkill(It.IsAny<List<int>>())).Returns(developers);

            // Act
            var result = _servMatch.MatchDeveloperToProject(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.DevelopersAptos);
            Assert.Equal(1, result.DevelopersAptos.First().Developer.Id);
        }

        [Fact]
        public void MatchProjectToDeveloperShouldReturnMatchedProjects()
        {
            // Arrange
            var developerId = 1;
            var developer = new Developer
            {
                Id = developerId,
                ExperienceLevel = EnumExperienceLevel.Pleno,
                DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill> { new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 } }
            };
            var projects = new List<Project>
                {
                    new Project
                    {
                        Id = 1,
                        Name = "Project1",
                        Description = "Description1",
                        MinimumExperienceLevel =  EnumExperienceLevel.Junior,
                        ProjectSkills = new List<ProjectSkill> { new ProjectSkill { SkillId = 1 } }
                    }
                };

            _mockServDeveloper.Setup(s => s.GetDeveloperById(developerId)).Returns(developer);
            _mockServProject.Setup(s => s.GetProjectAptosBySkill(It.IsAny<List<int>>())).Returns(projects);

            // Act
            var result = _servMatch.MatchProjectToDeveloper(developerId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.ProjectsAptos);
            Assert.Equal(1, result.ProjectsAptos.First().Project.Id);
        }
    }
}
