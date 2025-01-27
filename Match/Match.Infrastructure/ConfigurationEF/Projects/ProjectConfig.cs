using DomainProject = Match.Domain.Project.Project;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.ConfigurationEF.Projects
{
    public class ProjectConfig : IEntityTypeConfiguration<DomainProject>
    {
        public void Configure(EntityTypeBuilder<DomainProject> builder)
        {
            builder.ToTable("PROJECT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnName("NAME")
                   .IsRequired();

            builder.Property(x => x.Id)
                   .HasColumnName("IDPROJECT")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                   .HasColumnName("DESCRIPTION")
                   .IsRequired();

            builder.Property(x => x.DeveloperSlots)
                   .HasColumnName("DEVELOPERSLOTS")
                   .IsRequired();

            builder.Property(x => x.MinimumExperienceLevel)
                   .HasColumnName("MINIMU_EXPERIENCE_LEVEL")
                   .IsRequired();


        }
    }
}

