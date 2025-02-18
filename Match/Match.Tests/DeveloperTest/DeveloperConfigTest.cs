using Match.Infrastructure.ConfigurationEF.Developer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Tests.DeveloperTest
{
    public class DeveloperConfigTest
    {
        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Developer.Developer>();

            // Act
            new DeveloperConfig().Configure(builder);

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
            var builder = modelBuilder.Entity<Domain.Developer.Developer>();

            // Act
            new DeveloperConfig().Configure(builder);

            // Assert
            var name = builder.Metadata.FindProperty("Name");
            var id = builder.Metadata.FindProperty("Id");
            var email = builder.Metadata.FindProperty("Email");
            var experienceLevel = builder.Metadata.FindProperty("ExperienceLevel");

            Assert.True(!name.IsNullable);
            Assert.True(!id.IsNullable);
            Assert.True(!email.IsNullable);
            Assert.True(!experienceLevel.IsNullable);
        }

        [Fact]
        public void ConfigureSetsIdValueGeneratedOnAdd()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.Developer.Developer>();

            // Act
            new DeveloperConfig().Configure(builder);

            // Assert
            var id = builder.Metadata.FindProperty("Id");
            Assert.Equal(ValueGenerated.OnAdd, id.ValueGenerated);
        }
    }
}
