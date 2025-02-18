using Match.Infrastructure;
using Match.Infrastructure.DeveloperSkill;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.DeveloperSkillTest
{
    public class RepDeveloperSkillTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetDevelopersAptosBySkill_ShouldReturnDevelopersWithGivenSkills()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepDeveloperSkill(context);

            context.DeveloperSkill.AddRange(
                new Domain.DeveloperSkill.DeveloperSkill { DeveloperId = 1, SkillId = 1 },
                new Domain.DeveloperSkill.DeveloperSkill { DeveloperId = 2, SkillId = 2 },
                new Domain.DeveloperSkill.DeveloperSkill { DeveloperId = 1, SkillId = 2 }
            );
            context.SaveChanges();

            var skillIds = new List<int> { 1, 2 };

            // Act
            var developers = repository.GetDevelopersAptosBySkill(skillIds);

            // Assert
            Assert.Equal(2, developers.Count);
            Assert.Contains(1, developers);
            Assert.Contains(2, developers);
        }

        [Fact]
        public void GetDevelopersAptosBySkill_ShouldReturnEmptyList_WhenNoDevelopersHaveGivenSkills()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepDeveloperSkill(context);

            var skillIds = new List<int> { 1, 2 };

            // Act
            var developers = repository.GetDevelopersAptosBySkill(skillIds);

            // Assert
            Assert.Empty(developers);
        }
    }
}
