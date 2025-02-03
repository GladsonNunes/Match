using Match.Domain.Developer;
using Match.Domain.Match;
using Match.Domain.Match.DTO;
using Match.Domain.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Domain.MatchNotification
{
    public class ServMatchNotification : IServMatchNotification
    {
        private readonly IRepMatchNotification _repMatchNotification;
        public ServMatchNotification(IRepMatchNotification repMatchNotification) 
        { 
            _repMatchNotification = repMatchNotification;
        }
        public void NotificationProject(int ProjectId, int DeveloperId)
        {
            _repMatchNotification.Add(new MatchNotification
            {
                Id = 0,
                DateCreated = DateTime.Now,
                DeveloperId = DeveloperId,
                Message = $"Request for participation in Project {ProjectId} by developer {DeveloperId}",
                NotificationType = EnumTypeMatch.DeveloperToProject,
                ProjectId = ProjectId,
                ReadStatus = false
                
            });

        }
        public void NotificationDeveloper(List<DeveloperIdDTO> listDeveloperId, int ProjectId)
        {
            foreach (var developer in listDeveloperId)
            {
                _repMatchNotification.Add(new MatchNotification
                {
                    Id = 0,
                    DateCreated = DateTime.Now,
                    DeveloperId = developer.DeveloperId,
                    Message = $"Project {ProjectId} requested the participation of developer {developer.DeveloperId}",
                    NotificationType = EnumTypeMatch.ProjectToDeveloper,
                    ProjectId = ProjectId,
                    ReadStatus = false

                });
            }
        }
    }
}
