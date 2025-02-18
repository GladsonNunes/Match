using Match.Infrastructure.ConfigurationEF.ProjectSkill;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.ProjectSkillTest
{
    public class ProjectSkillConfigTest
    {
        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.ProjectSkill.ProjectSkill>();

            // Act
            new ProjectSkillConfig().Configure(builder);

            // Assert
            var key = builder.Metadata.FindPrimaryKey();
            Assert.NotNull(key);
            Assert.Contains(key.Properties, p => p.Name == "ProjectId");
            Assert.Contains(key.Properties, p => p.Name == "SkillId");
        }

        [Fact]
        public void ConfigureSetsColumnNames()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.ProjectSkill.ProjectSkill>();

            // Act
            new ProjectSkillConfig().Configure(builder);

            // Assert
            var skillId = builder.Metadata.FindProperty("SkillId");
            var projectId = builder.Metadata.FindProperty("ProjectId");

            Assert.Equal("IDSKILL", skillId.GetColumnName());
            Assert.Equal("IDPROJECT", projectId.GetColumnName());
        }

        [Fact]
        public void ConfigureSetsRelationships()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.ProjectSkill.ProjectSkill>();

            // Act
            new ProjectSkillConfig().Configure(builder);

            // Assert
            var projectNavigation = builder.Metadata.FindNavigation(nameof(Domain.ProjectSkill.ProjectSkill.Project));
            var skillNavigation = builder.Metadata.FindNavigation(nameof(Domain.ProjectSkill.ProjectSkill.Skill));

            Assert.NotNull(projectNavigation);
            Assert.NotNull(skillNavigation);
            Assert.Equal(DeleteBehavior.Cascade, projectNavigation.ForeignKey.DeleteBehavior);
            Assert.Equal(DeleteBehavior.Cascade, skillNavigation.ForeignKey.DeleteBehavior);
        }
    }
}
