using Match.Infrastructure;
using Match.Infrastructure.MatchNotification;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.MatchNotificationTest
{
    public class RepMatchNotificationTest
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetAllShouldReturnAllMatchNotifications()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchNotification(context);

            context.Set<Domain.MatchNotification.MatchNotification>().AddRange(
                new Domain.MatchNotification.MatchNotification { Id = 1, Message = "Notification 1", DateCreated = DateTime.Now },
                new Domain.MatchNotification.MatchNotification { Id = 2, Message = "Notification 2", DateCreated = DateTime.Now }
            );
            context.SaveChanges();

            // Act
            var notifications = repository.GetAll().ToList();

            // Assert
            Assert.Equal(2, notifications.Count);
            Assert.Contains(notifications, n => n.Id == 1);
            Assert.Contains(notifications, n => n.Id == 2);
        }

        [Fact]
        public void GetByIdShouldReturnMatchNotificationWhenExists()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchNotification(context);

            var notification = new Domain.MatchNotification.MatchNotification { Id = 1, Message = "Notification 1", DateCreated = DateTime.Now };
            context.Set<Domain.MatchNotification.MatchNotification>().Add(notification);
            context.SaveChanges();

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenMatchNotificationDoesNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchNotification(context);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddShouldAddMatchNotificationToDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchNotification(context);
            var notification = new Domain.MatchNotification.MatchNotification { Id = 1, Message = "Notification 1", DateCreated = DateTime.Now };

            // Act
            repository.Add(notification);
            var savedNotification = context.Set<Domain.MatchNotification.MatchNotification>().Find(1);

            // Assert
            Assert.NotNull(savedNotification);
            Assert.Equal(1, savedNotification.Id);
        }

        [Fact]
        public void Update_ShouldModifyMatchNotification()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchNotification(context);
            var notification = new Domain.MatchNotification.MatchNotification { Id = 1, Message = "Notification 1", DateCreated = DateTime.Now };
            context.Set<Domain.MatchNotification.MatchNotification>().Add(notification);
            context.SaveChanges();

            // Act
            notification.Message = "Updated Notification";
            repository.Update(notification);
            var updatedNotification = context.Set<Domain.MatchNotification.MatchNotification>().Find(1);

            // Assert
            Assert.NotNull(updatedNotification);
            Assert.Equal("Updated Notification", updatedNotification.Message);
        }

        [Fact]
        public void Delete_ShouldRemoveMatchNotificationFromDatabase()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var repository = new RepMatchNotification(context);
            var notification = new Domain.MatchNotification.MatchNotification { Id = 1, Message = "Notification 1", DateCreated = DateTime.Now };
            context.Set<Domain.MatchNotification.MatchNotification>().Add(notification);
            context.SaveChanges();

            // Act
            repository.Delete(1);
            var deletedNotification = context.Set<Domain.MatchNotification.MatchNotification>().Find(1);

            // Assert
            Assert.Null(deletedNotification);
        }
    }
}
