using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Match.Infrastructure.ConfigurationEF.Match
{
    public class MatchConfig : IEntityTypeConfiguration<Domain.Match.Match>
    {
        public void Configure(EntityTypeBuilder<Domain.Match.Match> builder)
        {
            builder.HasKey(m => m.Id);


            builder.Property(m => m.StatusProcessed)
                   .IsRequired();

            builder.Property(m => m.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(m => m.TypeMatch)
                   .IsRequired();

            builder.Property(m => m.DateMatch)
                   .IsRequired();
        }
    }

}
