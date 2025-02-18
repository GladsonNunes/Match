using Match.Infrastructure;
using Match.Infrastructure.Developer;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Match.Tests.DeveloperTest
{
    public class RepDeveloperTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void AddDeveloper_ShouldAddDeveloperToDatabase()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var developer = new Domain.Developer.Developer
                {
                    Email = "Dev@examplo.com",
                    ExperienceLevel = Domain.Developer.EnumExperienceLevel.Pleno,
                    Id = 1,
                    Name = "Dev"
                };
                developer.DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill> { new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 } };
                
                context.Developer.Add(developer);
                context.SaveChanges();

                Assert.Equal(1, context.Developer.Where(p=>p.Id==1).Count());
                Assert.Equal(developer, context.Developer.First());
            }
        }

        [Fact]
        public void GetDeveloper_ShouldReturnDeveloperFromDatabase()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var developer = new Domain.Developer.Developer
                {
                    Email = "Dev@examplo.com",
                    ExperienceLevel = Domain.Developer.EnumExperienceLevel.Pleno,
                    Id = 4,
                    Name = "Dev"
                };
                developer.DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill> { new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 } };
                context.Developer.Add(developer);
                context.SaveChanges();

                var retrievedDeveloper = context.Developer.Find(developer.Id);

                Assert.NotNull(retrievedDeveloper);
                Assert.Equal(developer, retrievedDeveloper);
            }
        }

        [Fact]
        public void UpdateDeveloper_ShouldUpdateDeveloperInDatabase()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var developer = new Domain.Developer.Developer
                {
                    Email = "Dev@examplo.com",
                    ExperienceLevel = Domain.Developer.EnumExperienceLevel.Pleno,
                    Id = 3,
                    Name = "Dev"
                };
                developer.DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill> { new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 } };
                context.Developer.Add(developer);
                context.SaveChanges();

                developer.Name = "Updated Name";
                context.Developer.Update(developer);
                context.SaveChanges();

                var updatedDeveloper = context.Developer.Find(developer.Id);

                Assert.NotNull(updatedDeveloper);
                Assert.Equal("Updated Name", updatedDeveloper.Name);
            }
        }

        [Fact]
        public void DeleteDeveloper_ShouldRemoveDeveloperFromDatabase()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var developer = new Domain.Developer.Developer
                {
                    Email = "Dev@examplo.com",
                    ExperienceLevel = Domain.Developer.EnumExperienceLevel.Pleno,
                    Id = 2,
                    Name = "Dev"
                };
                developer.DeveloperSkills = new List<Domain.DeveloperSkill.DeveloperSkill> { new Domain.DeveloperSkill.DeveloperSkill { SkillId = 1 } };
                context.Developer.Add(developer);
                context.SaveChanges();

                context.Developer.Remove(developer);
                context.SaveChanges();

                var deletedDeveloper = context.Developer.Find(developer.Id);

                Assert.Null(deletedDeveloper);
            }
        }
    }
}
