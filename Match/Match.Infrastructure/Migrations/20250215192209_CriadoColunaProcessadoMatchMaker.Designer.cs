﻿// <auto-generated />
using System;
using Match.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Match.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250215192209_CriadoColunaProcessadoMatchMaker")]
    partial class CriadoColunaProcessadoMatchMaker
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Match.Domain.Developer.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDDEVELOPER");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAIL");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("EXPERIENCE_LEVEL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("DEVELOPER", (string)null);
                });

            modelBuilder.Entity("Match.Domain.DeveloperSkill.DeveloperSkill", b =>
                {
                    b.Property<int>("DeveloperId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDDEVELOPER");

                    b.Property<int>("SkillId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDSKILL");

                    b.HasKey("DeveloperId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("DEVELOPER_SKILL", (string)null);
                });

            modelBuilder.Entity("Match.Domain.Match.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateMatch")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("StatusProcessed")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("TypeMatch")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Match.Domain.MatchMaker.MatchMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDMATCHMAKER");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MatchId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDMATCH");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDDEVELOPER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDPROJECT");

                    b.Property<int>("StatusProcessedMatchMaker")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS_PROCESSED_MATCH_MAKER)");

                    b.HasKey("Id", "MatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("MATCH_MAKER", (string)null);
                });

            modelBuilder.Entity("Match.Domain.MatchNotification.MatchNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDNOTIFICATION");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATE_CREATED");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDDEVELOPER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MESSAGE");

                    b.Property<int>("NotificationType")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("NOTIFICATION_TYPE");

                    b.Property<int>("ProjectId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDPROJECT");

                    b.Property<bool>("ReadStatus")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("READ_STATUS");

                    b.HasKey("Id");

                    b.ToTable("MATCH_NOTIFICATION", (string)null);
                });

            modelBuilder.Entity("Match.Domain.Project.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDPROJECT");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("DeveloperSlots")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DEVELOPERSLOTS");

                    b.Property<int>("MinimumExperienceLevel")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MINIMU_EXPERIENCE_LEVEL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("PROJECT", (string)null);
                });

            modelBuilder.Entity("Match.Domain.ProjectSkill.ProjectSkill", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDPROJECT");

                    b.Property<int>("SkillId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDSKILL");

                    b.HasKey("ProjectId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PROJECT_SKILL", (string)null);
                });

            modelBuilder.Entity("Match.Domain.Skill.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IDSKILL");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("SKILL", (string)null);
                });

            modelBuilder.Entity("Match.Domain.DeveloperSkill.DeveloperSkill", b =>
                {
                    b.HasOne("Match.Domain.Developer.Developer", "Developer")
                        .WithMany("DeveloperSkills")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Match.Domain.Skill.Skill", "Skill")
                        .WithMany("DeveloperSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Match.Domain.MatchMaker.MatchMaker", b =>
                {
                    b.HasOne("Match.Domain.Match.Match", "Match")
                        .WithMany("MatchMakers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Match.Domain.ProjectSkill.ProjectSkill", b =>
                {
                    b.HasOne("Match.Domain.Project.Project", "Project")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Match.Domain.Skill.Skill", "Skill")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Match.Domain.Developer.Developer", b =>
                {
                    b.Navigation("DeveloperSkills");
                });

            modelBuilder.Entity("Match.Domain.Match.Match", b =>
                {
                    b.Navigation("MatchMakers");
                });

            modelBuilder.Entity("Match.Domain.Project.Project", b =>
                {
                    b.Navigation("ProjectSkills");
                });

            modelBuilder.Entity("Match.Domain.Skill.Skill", b =>
                {
                    b.Navigation("DeveloperSkills");

                    b.Navigation("ProjectSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
