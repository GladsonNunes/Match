using Match.Domain.Match;
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
        void NotificationDeveloper(List<DeveloperIdDTO> listDeveloperId, int ProjectId, EnumStatusProcessed statusProcessed);
        void NotificationProject(int ProjectId, int DeveloperId, EnumStatusProcessed statusProcessed);
    }
}
