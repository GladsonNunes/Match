using DomainDeveloper = Match.Domain.Developer.Developer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.ConfigurationEF.Developer
{
    public class DeveloperConfig : IEntityTypeConfiguration<DomainDeveloper>
    {
        public void Configure(EntityTypeBuilder<DomainDeveloper> builder)
        {
            builder.ToTable("DEVELOPER");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnName("NAME")
                   .IsRequired();

            builder.Property(x => x.Id)
                   .HasColumnName("IDDEVELOPER")
                   .ValueGeneratedOnAdd();


            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .IsRequired();

            builder.Property(x => x.ExperienceLevel)
                    .HasColumnName("EXPERIENCE_LEVEL")
                .IsRequired();
        }
    }
}
