using Match.Domain.Match;
using Match.Infrastructure;
using Match.Infrastructure.MatchMaker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Tests.MatchMakerTest
{
    public class RepMatchMakerTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetAllShouldReturnAllMatchMakers()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchMaker(context);

            context.Set<Domain.MatchMaker.MatchMaker>().AddRange(
                new Domain.MatchMaker.MatchMaker { Id = 1, ProjectId = 1, MatchId = 1, DeveloperId = 1, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch },
                new Domain.MatchMaker.MatchMaker { Id = 2, ProjectId = 2, MatchId = 2, DeveloperId = 2, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch }
            );
            context.SaveChanges();

            // Act
            var matchMakers = repository.GetAll().ToList();

            // Assert
            Assert.Equal(2, matchMakers.Count);
            Assert.Contains(matchMakers, mm => mm.Id == 1);
            Assert.Contains(matchMakers, mm => mm.Id == 2);
        }

        [Fact]
        public void GetByIdShouldReturnMatchMakerWhenMatchMakerExists()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchMaker(context);

            var matchMaker = new Domain.MatchMaker.MatchMaker { Id = 1, ProjectId = 1, MatchId = 1, DeveloperId = 1, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch };
            context.Set<Domain.MatchMaker.MatchMaker>().Add(matchMaker);
            context.SaveChanges();

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetByIdShouldReturnNullWhenMatchMakerDoesNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchMaker(context);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddShouldAddMatchMakerToDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchMaker(context);
            var matchMaker = new Domain.MatchMaker.MatchMaker { Id = 1, ProjectId = 1, MatchId = 1, DeveloperId = 1, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch };
            
            // Act
            repository.Add(matchMaker);
            var savedMatchMaker = context.Set<Domain.MatchMaker.MatchMaker>().Find(1,1);

            // Assert
            Assert.NotNull(savedMatchMaker);
            Assert.Equal(1, savedMatchMaker.Id);
        }

        [Fact]
        public void UpdateShouldModifyMatchMaker()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchMaker(context);
            var matchMaker = new Domain.MatchMaker.MatchMaker { Id = 1, ProjectId = 1, MatchId = 1, DeveloperId = 1, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch };
            context.Set<Domain.MatchMaker.MatchMaker>().Add(matchMaker);
            context.SaveChanges();

            // Act
            matchMaker.StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.MatchAccepted;
            repository.Update(matchMaker);
            var updatedMatchMaker = context.Set<Domain.MatchMaker.MatchMaker>().Find(1,1);

            // Assert
            Assert.NotNull(updatedMatchMaker);
            Assert.Equal(EnumStatusProcessedMatchMakers.MatchAccepted, updatedMatchMaker.StatusProcessedMatchMaker);
        }

        [Fact]
        public void DeleteShouldRemoveMatchMakerFromDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchMaker(context);
            var matchMaker = new Domain.MatchMaker.MatchMaker { Id = 1, ProjectId = 1, MatchId = 1, DeveloperId = 1, StatusProcessedMatchMaker = EnumStatusProcessedMatchMakers.WaitingForMatch };
            context.Set<Domain.MatchMaker.MatchMaker>().Add(matchMaker);
            context.SaveChanges();

            // Act
            repository.Delete(1);
            var deletedMatchMaker = context.Set<Domain.MatchMaker.MatchMaker>().Find(1, 1);

            // Assert
            Assert.Null(deletedMatchMaker);
        }
    }
}
