using Match.Infrastructure;
using Match.Infrastructure.ProjectSkill;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.ProjectSkillTest
{
    public class RepProjectSkillTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetProjectAptosBySkillShouldReturnProjectIdsWhenSkillsExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProjectSkill(context);

            context.Set<Domain.ProjectSkill.ProjectSkill>().AddRange(
                new Domain.ProjectSkill.ProjectSkill { ProjectId = 1, SkillId = 1 },
                new Domain.ProjectSkill.ProjectSkill { ProjectId = 2, SkillId = 1 },
                new Domain.ProjectSkill.ProjectSkill { ProjectId = 3, SkillId = 2 }
            );
            context.SaveChanges();

            var skillIds = new List<int> { 1 };

            // Act
            var result = repository.GetProjectAptosBySkill(skillIds);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(1, result);
            Assert.Contains(2, result);
        }

        [Fact]
        public void GetProjectAptosBySkillShouldReturnEmptyListWhenSkillsDoNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepProjectSkill(context);

            var skillIds = new List<int> { 99 };

            // Act
            var result = repository.GetProjectAptosBySkill(skillIds);

            // Assert
            Assert.Empty(result);
        }
    }
}
