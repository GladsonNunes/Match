using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.ConfigurationEF.MatchMaker
{
    public class MatchMakerConfig : IEntityTypeConfiguration<Domain.MatchMaker.MatchMaker>
    {
        public void Configure(EntityTypeBuilder<Domain.MatchMaker.MatchMaker> builder)
        {
            builder.ToTable("MATCH_MAKER");
            builder.HasKey(ds => new { ds.Id, ds.MatchId });

            builder.Property(x => x.DeveloperId)
                 .HasColumnName("IDDEVELOPER");

            builder.Property(x => x.ProjectId)
                .HasColumnName("IDPROJECT");

            builder.Property(x => x.MatchId)
                .HasColumnName("IDMATCH");

            builder.Property(x => x.Id)
                .HasColumnName("IDIDMATCHMAKER");

            builder.HasOne(ds => ds.Match)
               .WithMany(d => d.MatchMakers)
               .HasForeignKey(ds => ds.MatchId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

