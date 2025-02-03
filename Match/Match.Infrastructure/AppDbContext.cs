using Match.Infrastructure.ConfigurationEF.Developer;
using Match.Infrastructure.ConfigurationEF.DeveloperSkill;
using Match.Infrastructure.ConfigurationEF.Projects;
using Match.Infrastructure.ConfigurationEF.ProjectSkill;
using Match.Infrastructure.ConfigurationEF.Skill;
using Microsoft.EntityFrameworkCore;
using DomainDeveloper = Match.Domain.Developer.Developer;
using DomainProject = Match.Domain.Project.Project;
using DomainSkill = Match.Domain.Skill.Skill;
using DomainDeveloperSkill = Match.Domain.DeveloperSkill.DeveloperSkill;
using DomainProjectSkill = Match.Domain.ProjectSkill.ProjectSkill;
using Match.Infrastructure.ConfigurationEF.Match;
using Match.Infrastructure.ConfigurationEF.MatchMaker;
using Match.Infrastructure.ConfigurationEF.MatchNotification;

namespace Match.Infrastructure
{
    public class AppDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
        // DbSet para cada entidade do domínio
        public DbSet<DomainDeveloper> Developer { get; set; }
        public DbSet<DomainProject> Project { get; set; }
        public DbSet<DomainSkill> Skill { get; set; }
        public DbSet<DomainDeveloperSkill> DeveloperSkill { get; set; }
        public DbSet<DomainProjectSkill> ProjectSkill { get; set; }
        public DbSet<Domain.Match.Match> Match { get; set; }
        public DbSet<Domain.MatchMaker.MatchMaker> MatchMaker { get; set; }
        public DbSet<Domain.MatchNotification.MatchNotification> MatchNotification { get; set; }


        // Configuração do modelo (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DeveloperConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new SkillConfig());
            modelBuilder.ApplyConfiguration(new DeveloperSkillConfig());
            modelBuilder.ApplyConfiguration(new ProjectSkillConfig());
            modelBuilder.ApplyConfiguration(new MatchConfig());
            modelBuilder.ApplyConfiguration(new MatchMakerConfig());
            modelBuilder.ApplyConfiguration(new MatchNotificationConfig());
            

        }
    }
}

