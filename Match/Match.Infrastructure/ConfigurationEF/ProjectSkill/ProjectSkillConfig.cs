using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainProjectSkill = Match.Domain.ProjectSkill.ProjectSkill;

namespace Match.Infrastructure.ConfigurationEF.ProjectSkill
{
    public class ProjectSkillConfig : IEntityTypeConfiguration<DomainProjectSkill>
    {
        public void Configure(EntityTypeBuilder<DomainProjectSkill> builder)
        {
            builder.ToTable("PROJECT_SKILL");

            builder.HasKey(ps => new { ps.ProjectId, ps.SkillId });

            builder.Property(x => x.SkillId)
                  .HasColumnName("IDSKILL");

            builder.Property(x => x.ProjectId)
                 .HasColumnName("IDPROJECT");


            builder.HasOne(ds => ds.Project)
               .WithMany(d => d.ProjectSkills)
               .HasForeignKey(ds => ds.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ds => ds.Skill)
              .WithMany(s => s.ProjectSkills)
              .HasForeignKey(ds => ds.SkillId)
              .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
