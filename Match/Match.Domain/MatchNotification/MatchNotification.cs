using Match.Domain.Match;

namespace Match.Domain.MatchNotification
{
    public class MatchNotification
    {
        public int Id { get; set; }  
        public string Message { get; set; }  
        public EnumTypeMatch NotificationType { get; set; }  
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateCreated { get; set; }  
        public bool ReadStatus { get; set; }  
    }
}
