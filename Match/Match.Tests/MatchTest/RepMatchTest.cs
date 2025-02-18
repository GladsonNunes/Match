using Match.Domain.Match;
using Match.Domain.MatchMaker;
using Match.Infrastructure;
using Match.Infrastructure.Match;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Match.Tests.MatchTest
{
    public class RepMatchTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetAllShouldReturnAllMatches()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatch(context);

            context.Set<Domain.Match.Match>().AddRange(
                new Domain.Match.Match
                {
                    Id = 1,
                    TypeMatch = EnumTypeMatch.DeveloperToProject,
                    DateMatch = DateTime.Now,
                    MatchMakers = new List<MatchMaker>
                    {
                        new MatchMaker { Id = 1, ProjectId = 1, MatchId = 1, DeveloperId = 1, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch }
                    }
                },
                new Domain.Match.Match
                {
                    Id = 2,
                    TypeMatch = EnumTypeMatch.ProjectToDeveloper,
                    DateMatch = DateTime.Now,
                    MatchMakers = new List<MatchMaker>
                    {
                        new MatchMaker { Id = 2, ProjectId = 2, MatchId = 2, DeveloperId = 2, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch }
                    }
                }
            );
            context.SaveChanges();

            // Act
            var matches = repository.GetAll().ToList();

            // Assert
            Assert.Equal(2, matches.Count);
            Assert.Contains(matches, m => m.Id == 1);
            Assert.Contains(matches, m => m.Id == 2);
        }

        [Fact]
        public void GetByIdShouldReturnMatchWhenMatchExists()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatch(context);

            var match = new Domain.Match.Match { Id = 1, TypeMatch = EnumTypeMatch.ProjectToDeveloper, DateMatch = DateTime.Now };
            context.Set<Domain.Match.Match>().Add(match);
            context.SaveChanges();

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenMatchDoesNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatch(context);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddShouldAddMatchToDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatch(context);
            var match = new Domain.Match.Match { Id = 1, TypeMatch = EnumTypeMatch.ProjectToDeveloper, DateMatch = DateTime.Now };

            // Act
            repository.Add(match);
            var savedMatch = context.Set<Domain.Match.Match>().Find(1);

            // Assert
            Assert.NotNull(savedMatch);
            Assert.Equal(1, savedMatch.Id);
        }

        [Fact]
        public void Update_ShouldModifyMatch()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatch(context);
            var match = new Domain.Match.Match { Id = 1, TypeMatch = EnumTypeMatch.ProjectToDeveloper, DateMatch = DateTime.Now };
            context.Set<Domain.Match.Match>().Add(match);
            context.SaveChanges();

            // Act
            match.TypeMatch = EnumTypeMatch.DeveloperToProject;
            repository.Update(match);
            var updatedMatch = context.Set<Domain.Match.Match>().Find(1);

            // Assert
            Assert.NotNull(updatedMatch);
            Assert.Equal(EnumTypeMatch.DeveloperToProject, updatedMatch.TypeMatch);
        }

        [Fact]
        public void Delete_ShouldRemoveMatchFromDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatch(context);
            var match = new Domain.Match.Match { Id = 1, TypeMatch = EnumTypeMatch.ProjectToDeveloper, DateMatch = DateTime.Now };
            context.Set<Domain.Match.Match>().Add(match);
            context.SaveChanges();

            // Act
            repository.Delete(1);
            var deletedMatch = context.Set<Domain.Match.Match>().Find(1);

            // Assert
            Assert.Null(deletedMatch);
        }
    }
}
