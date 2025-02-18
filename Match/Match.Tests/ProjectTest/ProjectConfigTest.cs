using Match.Infrastructure.ConfigurationEF.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Match.Tests.ProjectTest
{
    public class ProjectConfigTest
    {
        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Project.Project>();

            // Act
            new ProjectConfig().Configure(builder);

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
            var builder = modelBuilder.Entity<Domain.Project.Project>();

            // Act
            new ProjectConfig().Configure(builder);

            // Assert
            var name = builder.Metadata.FindProperty("Name");
            var description = builder.Metadata.FindProperty("Description");
            var developerSlots = builder.Metadata.FindProperty("DeveloperSlots");
            var minimumExperienceLevel = builder.Metadata.FindProperty("MinimumExperienceLevel");

            Assert.True(!name.IsNullable);
            Assert.True(!description.IsNullable);
            Assert.True(!developerSlots.IsNullable);
            Assert.True(!minimumExperienceLevel.IsNullable);
        }

        [Fact]
        public void ConfigureSetsIdValueGeneratedOnAdd()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Project.Project>();

            // Act
            new ProjectConfig().Configure(builder);

            // Assert
            var id = builder.Metadata.FindProperty("Id");
            Assert.Equal(ValueGenerated.OnAdd, id.ValueGenerated);
        }
    }
}
