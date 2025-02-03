using Match.Domain.Match.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match.Domain.MatchNotification
{
    public interface IServMatchNotification
    {
        void NotificationDeveloper(List<DeveloperIdDTO> listDeveloperId, int ProjectId);
        void NotificationProject(int ProjectId, int DeveloperId);
    }
}
