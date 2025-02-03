using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Match.Infrastructure.ConfigurationEF.MatchNotification
{
    public class MatchNotificationConfig : IEntityTypeConfiguration<Domain.MatchNotification.MatchNotification>
    {
        public void Configure(EntityTypeBuilder<Domain.MatchNotification.MatchNotification> builder)
        {
            builder.ToTable("MATCH_NOTIFICATION");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDNOTIFICATION");
            
            builder.Property(x => x.DeveloperId)
                .HasColumnName("IDDEVELOPER");

            builder.Property(x => x.Message)
                .HasColumnName("MESSAGE");

            builder.Property(x => x.NotificationType)
                .HasColumnName("NOTIFICATION_TYPE");

            builder.Property(x => x.DateCreated)
                .HasColumnName("DATE_CREATED");

            builder.Property(x => x.ProjectId)
                .HasColumnName("IDPROJECT");

            builder.Property(x => x.ReadStatus)
                .HasColumnName("READ_STATUS");
        }
    }
}
