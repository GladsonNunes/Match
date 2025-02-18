using Match.Infrastructure.ConfigurationEF.DeveloperSkill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Match.Tests.DeveloperSkillTest
{
    public class DeveloperSkillConfigTest
    {
        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.DeveloperSkill.DeveloperSkill>();

            // Act
            new DeveloperSkillConfig().Configure(builder);

            // Assert
            var key = builder.Metadata.FindPrimaryKey();
            Assert.NotNull(key);
            Assert.Contains(key.Properties, p => p.Name == "DeveloperId");
            Assert.Contains(key.Properties, p => p.Name == "SkillId");
        }

        [Fact]
        public void ConfigureSetsColumnNames()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.DeveloperSkill.DeveloperSkill>();

            // Act
            new DeveloperSkillConfig().Configure(builder);

            // Assert
            var skillId = builder.Metadata.FindProperty("SkillId");
            var developerId = builder.Metadata.FindProperty("DeveloperId");

            Assert.Equal("IDSKILL", skillId.GetColumnName(StoreObjectIdentifier.Table("DEVELOPER_SKILL", null)));
            Assert.Equal("IDDEVELOPER", developerId.GetColumnName(StoreObjectIdentifier.Table("DEVELOPER_SKILL", null)));
        }

        [Fact]
        public void ConfigureSetsForeignKeys()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.DeveloperSkill.DeveloperSkill>();

            // Act
            new DeveloperSkillConfig().Configure(builder);

            // Assert
            var developerFk = builder.Metadata.FindNavigation(nameof(Domain.DeveloperSkill.DeveloperSkill.Developer)).ForeignKey;
            var skillFk = builder.Metadata.FindNavigation(nameof(Domain.DeveloperSkill.DeveloperSkill.Skill)).ForeignKey;

            Assert.Equal(DeleteBehavior.Cascade, developerFk.DeleteBehavior);
            Assert.Equal(DeleteBehavior.Cascade, skillFk.DeleteBehavior);
        }
    }
}
