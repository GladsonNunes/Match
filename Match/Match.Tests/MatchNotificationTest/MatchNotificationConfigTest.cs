using Match.Domain.MatchNotification;
using Match.Infrastructure.ConfigurationEF.Match;
using Match.Infrastructure.ConfigurationEF.MatchNotification;
using Microsoft.EntityFrameworkCore;

namespace Match.Tests.MatchNotificationTest
{
    public class MatchNotificationConfigTest
    {
        [Fact]
        public void ConfigureShouldSetupEntity()
        {
            // Arrange
            var builder = new ModelBuilder();
            var entityBuilder = builder.Entity<MatchNotification>();

            var config = new MatchNotificationConfig();

            // Act
            config.Configure(entityBuilder);

            // Assert
            var entity = builder.Model.FindEntityType(typeof(MatchNotification));
            Assert.NotNull(entity);
            Assert.Equal("MATCH_NOTIFICATION", entity.GetTableName());
            Assert.Equal("IDNOTIFICATION", entity.FindProperty(nameof(MatchNotification.Id)).GetColumnName());
            Assert.Equal("IDDEVELOPER", entity.FindProperty(nameof(MatchNotification.DeveloperId)).GetColumnName());
            Assert.Equal("MESSAGE", entity.FindProperty(nameof(MatchNotification.Message)).GetColumnName());
            Assert.Equal("NOTIFICATION_TYPE", entity.FindProperty(nameof(MatchNotification.NotificationType)).GetColumnName());
            Assert.Equal("DATE_CREATED", entity.FindProperty(nameof(MatchNotification.DateCreated)).GetColumnName());
            Assert.Equal("IDPROJECT", entity.FindProperty(nameof(MatchNotification.ProjectId)).GetColumnName());
            Assert.Equal("READ_STATUS", entity.FindProperty(nameof(MatchNotification.ReadStatus)).GetColumnName());
        }

        [Fact]
        public void ConfigureSetsKey()
        {
            // Arrange
            var modelBuilder = new ModelBuilder();
            var builder = modelBuilder.Entity<Domain.MatchNotification.MatchNotification>();

            // Act
            new MatchNotificationConfig().Configure(builder);

            // Assert
            var key = builder.Metadata.FindPrimaryKey();
            Assert.NotNull(key);
            Assert.Contains(key.Properties, p => p.Name == "Id");
        }
    }

}
