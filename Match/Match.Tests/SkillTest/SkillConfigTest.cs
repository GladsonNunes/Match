using Match.Infrastructure.ConfigurationEF.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Match.Tests.SkillTest
{
    public class SkillConfigTest
    {
        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Skill.Skill>();

            // Act
            new SkillConfig().Configure(builder);

            // Assert
            var key = builder.Metadata.FindPrimaryKey();
            Assert.NotNull(key);
            Assert.Contains(key.Properties, p => p.Name == "Id");
        }

        [Fact]
        public void ConfigureSetsNotNullableProperties()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Skill.Skill>();

            // Act
            new SkillConfig().Configure(builder);

            // Assert
            var name = builder.Metadata.FindProperty("Name");
            var id = builder.Metadata.FindProperty("Id");

            Assert.True(!name.IsNullable);
            Assert.True(!id.IsNullable);
        }

        [Fact]
        public void ConfigureSetsIdValueGeneratedOnAdd()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Skill.Skill>();

            // Act
            new SkillConfig().Configure(builder);

            // Assert
            var id = builder.Metadata.FindProperty("Id");
            Assert.Equal(ValueGenerated.OnAdd, id.ValueGenerated);
        }
    }
}
