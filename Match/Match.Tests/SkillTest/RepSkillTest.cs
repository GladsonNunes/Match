using Match.Infrastructure;
using Match.Infrastructure.Skill;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.SkillTest
{
    public class RepSkillTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetAllShouldReturnAllSkills()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepSkill(context);

            context.Set<Domain.Skill.Skill>().AddRange(
                new Domain.Skill.Skill { Id = 1, Name = "C#" },
                new Domain.Skill.Skill { Id = 2, Name = "Java" }
            );
            context.SaveChanges();

            // Act
            var skills = repository.GetAll().ToList();

            // Assert
            Assert.Equal(2, skills.Count);
            Assert.Contains(skills, s => s.Id == 1);
            Assert.Contains(skills, s => s.Id == 2);
        }

        [Fact]
        public void GetByIdShouldReturnSkillWhenSkillExists()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepSkill(context);

            var skill = new Domain.Skill.Skill { Id = 1, Name = "C#" };
            context.Set<Domain.Skill.Skill>().Add(skill);
            context.SaveChanges();

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenSkillDoesNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepSkill(context);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddShouldAddSkillToDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepSkill(context);
            var skill = new Domain.Skill.Skill { Id = 1, Name = "C#" };

            // Act
            repository.Add(skill);
            var savedSkill = context.Set<Domain.Skill.Skill>().Find(1);

            // Assert
            Assert.NotNull(savedSkill);
            Assert.Equal(1, savedSkill.Id);
        }

        [Fact]
        public void Update_ShouldModifySkill()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepSkill(context);
            var skill = new Domain.Skill.Skill { Id = 1, Name = "C#" };
            context.Set<Domain.Skill.Skill>().Add(skill);
            context.SaveChanges();

            // Act
            skill.Name = "Java";
            repository.Update(skill);
            var updatedSkill = context.Set<Domain.Skill.Skill>().Find(1);

            // Assert
            Assert.NotNull(updatedSkill);
            Assert.Equal("Java", updatedSkill.Name);
        }

        [Fact]
        public void Delete_ShouldRemoveSkillFromDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepSkill(context);
            var skill = new Domain.Skill.Skill { Id = 1, Name = "C#" };
            context.Set<Domain.Skill.Skill>().Add(skill);
            context.SaveChanges();

            // Act
            repository.Delete(1);
            var deletedSkill = context.Set< Domain.Skill.Skill> ().Find(1);

            // Assert
            Assert.Null(deletedSkill);
        }
    }
}
