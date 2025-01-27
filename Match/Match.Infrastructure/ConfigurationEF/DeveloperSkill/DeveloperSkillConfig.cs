using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainDeveloperSkill = Match.Domain.DeveloperSkill.DeveloperSkill;

namespace Match.Infrastructure.ConfigurationEF.DeveloperSkill
{
    public class DeveloperSkillConfig : IEntityTypeConfiguration<DomainDeveloperSkill>
    {
        public void Configure(EntityTypeBuilder<DomainDeveloperSkill> builder)
        {
            builder.ToTable("DEVELOPER_SKILL");

            builder.HasKey(ds => new { ds.DeveloperId, ds.SkillId });

            builder.Property(x => x.SkillId)
                  .HasColumnName("IDSKILL");

            builder.Property(x => x.DeveloperId)
                 .HasColumnName("IDDEVELOPER");


            builder.HasOne(ds => ds.Developer)
               .WithMany(d => d.DeveloperSkills)
               .HasForeignKey(ds => ds.DeveloperId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ds => ds.Skill)
              .WithMany(s => s.DeveloperSkills)
              .HasForeignKey(ds => ds.SkillId)
              .OnDelete(DeleteBehavior.Cascade);


           
        }


    }
}
