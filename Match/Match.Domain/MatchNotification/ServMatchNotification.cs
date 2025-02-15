using Match.Domain.Match;
using Match.Domain.Match.DTO;

namespace Match.Domain.MatchNotification
{
    public class ServMatchNotification : IServMatchNotification
    {
        private readonly IRepMatchNotification _repMatchNotification;
        public ServMatchNotification(IRepMatchNotification repMatchNotification)
        {
            _repMatchNotification = repMatchNotification;
        }
        public void NotificationProject(int ProjectId, int DeveloperId, EnumStatusProcessed statusProcessed)
        {
            var message = statusProcessed switch
            {
                EnumStatusProcessed.Pending => $"Request for participation in Project {ProjectId} by developer {DeveloperId}",
                EnumStatusProcessed.Processed => $"Project participation request answered, check Project {ProjectId}",
            };

            _repMatchNotification.Add(new MatchNotification
            {
                Id = 0,
                DateCreated = DateTime.Now,
                DeveloperId = DeveloperId,
                Message = message,
                NotificationType = EnumTypeMatch.DeveloperToProject,
                ProjectId = ProjectId,
                ReadStatus = false
            });
        }
        public void NotificationDeveloper(List<DeveloperIdDTO> listDeveloperId, int ProjectId, EnumStatusProcessed statusProcessed)
        {
           

            foreach (var developer in listDeveloperId)
            {
                var message = statusProcessed switch
                {
                    EnumStatusProcessed.Pending => $"Project {ProjectId} requested the participation of developer {developer.DeveloperId}",
                    EnumStatusProcessed.Processed => $"Match request processed: check the list of developers" 
                };

                _repMatchNotification.Add(new MatchNotification
                {
                    Id = 0,
                    DateCreated = DateTime.Now,
                    DeveloperId = developer.DeveloperId,
                    Message = message,
                    NotificationType = EnumTypeMatch.ProjectToDeveloper,
                    ProjectId = ProjectId,
                    ReadStatus = false

                });
            }
        }
    }
}
