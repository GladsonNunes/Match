using Match.Infrastructure.ConfigurationEF.Match;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Match.Tests.MatchTest
{
    public class MatchConfigTest
    {
        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Match.Match>();

            // Act
            new MatchConfig().Configure(builder);

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
            var builder = modelBuilder.Entity<Domain.Match.Match>();

            // Act
            new MatchConfig().Configure(builder);

            // Assert
            var statusProcessed = builder.Metadata.FindProperty("StatusProcessed");
            var id = builder.Metadata.FindProperty("Id");
            var typeMatch = builder.Metadata.FindProperty("TypeMatch");
            var dateMatch = builder.Metadata.FindProperty("DateMatch");

            Assert.True(!statusProcessed.IsNullable);
            Assert.True(!id.IsNullable);
            Assert.True(!typeMatch.IsNullable);
            Assert.True(!dateMatch.IsNullable);
        }

        [Fact]
        public void ConfigureSetsIdValueGeneratedOnAdd()
        {

            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Match.Match>();
            // Act
            new MatchConfig().Configure(builder);

            // Assert
            var id = builder.Metadata.FindProperty("Id");
            Assert.Equal(ValueGenerated.OnAdd, id.ValueGenerated);
        }
    }
}
