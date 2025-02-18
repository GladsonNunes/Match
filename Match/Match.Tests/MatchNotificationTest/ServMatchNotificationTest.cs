using Match.Domain.Match;
using Match.Domain.Match.DTO;
using Match.Domain.MatchNotification;
using Moq;

namespace Match.Tests.MatchNotificationTest
{
    public class ServMatchNotificationTest
    {
        private readonly Mock<IRepMatchNotification> _mockRepMatchNotification;
        private readonly ServMatchNotification _servMatchNotification;

        public ServMatchNotificationTest()
        {
            _mockRepMatchNotification = new Mock<IRepMatchNotification>();
            _servMatchNotification = new ServMatchNotification(_mockRepMatchNotification.Object);
        }

        [Fact]
        public void NotificationProject_ShouldAddNotification()
        {
            // Arrange
            int projectId = 1;
            int developerId = 1;
            EnumStatusProcessed statusProcessed = EnumStatusProcessed.Pending;

            // Act
            _servMatchNotification.NotificationProject(projectId, developerId, statusProcessed);

            // Assert
            _mockRepMatchNotification.Verify(r => r.Add(It.Is<MatchNotification>(n =>
                n.ProjectId == projectId &&
                n.DeveloperId == developerId &&
                n.NotificationType == EnumTypeMatch.DeveloperToProject &&
                n.Message.Contains("Request for participation in Project") &&
                n.ReadStatus == false
            )), Times.Once);
        }

        [Fact]
        public void NotificationDeveloper_ShouldAddNotifications()
        {
            // Arrange
            int projectId = 1;
            var developers = new List<DeveloperIdDTO>
                {
                    new DeveloperIdDTO { DeveloperId = 1 },
                    new DeveloperIdDTO { DeveloperId = 2 }
                };
            EnumStatusProcessed statusProcessed = EnumStatusProcessed.Pending;

            // Act
            _servMatchNotification.NotificationDeveloper(developers, projectId, statusProcessed);

            // Assert
            _mockRepMatchNotification.Verify(r => r.Add(It.Is<MatchNotification>(n =>
                n.ProjectId == projectId &&
                developers.Any(d => d.DeveloperId == n.DeveloperId) &&
                n.NotificationType == EnumTypeMatch.ProjectToDeveloper &&
                n.Message.Contains("Project") &&
                n.ReadStatus == false
            )), Times.Exactly(developers.Count));
        }
    }
}
