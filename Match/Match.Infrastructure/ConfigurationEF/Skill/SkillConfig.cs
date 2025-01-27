using DomainSkill = Match.Domain.Skill.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Match.Infrastructure.ConfigurationEF.Skill
{
    public class SkillConfig : IEntityTypeConfiguration<DomainSkill>
    {
        public void Configure(EntityTypeBuilder<DomainSkill> builder)
        {
            builder.ToTable("SKILL");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnName("NAME")
                   .IsRequired();

            builder.Property(x => x.Id)
                   .HasColumnName("IDSKILL")
                   .ValueGeneratedOnAdd();

           
        }
    }
}
