using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Match.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEVELOPER",
                columns: table => new
                {
                    IDDEVELOPER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EXPERIENCE_LEVEL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVELOPER", x => x.IDDEVELOPER);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT",
                columns: table => new
                {
                    IDPROJECT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DEVELOPERSLOTS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MINIMU_EXPERIENCE_LEVEL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT", x => x.IDPROJECT);
                });

            migrationBuilder.CreateTable(
                name: "SKILL",
                columns: table => new
                {
                    IDSKILL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKILL", x => x.IDSKILL);
                });

            migrationBuilder.CreateTable(
                name: "DEVELOPER_SKILL",
                columns: table => new
                {
                    IDDEVELOPER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IDSKILL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVELOPER_SKILL", x => new { x.IDDEVELOPER, x.IDSKILL });
                    table.ForeignKey(
                        name: "FK_DEVELOPER_SKILL_DEVELOPER_IDDEVELOPER",
                        column: x => x.IDDEVELOPER,
                        principalTable: "DEVELOPER",
                        principalColumn: "IDDEVELOPER",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DEVELOPER_SKILL_SKILL_IDSKILL",
                        column: x => x.IDSKILL,
                        principalTable: "SKILL",
                        principalColumn: "IDSKILL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_SKILL",
                columns: table => new
                {
                    IDPROJECT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IDSKILL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_SKILL", x => new { x.IDPROJECT, x.IDSKILL });
                    table.ForeignKey(
                        name: "FK_PROJECT_SKILL_PROJECT_IDPROJECT",
                        column: x => x.IDPROJECT,
                        principalTable: "PROJECT",
                        principalColumn: "IDPROJECT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJECT_SKILL_SKILL_IDSKILL",
                        column: x => x.IDSKILL,
                        principalTable: "SKILL",
                        principalColumn: "IDSKILL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEVELOPER_SKILL_IDSKILL",
                table: "DEVELOPER_SKILL",
                column: "IDSKILL");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_SKILL_IDSKILL",
                table: "PROJECT_SKILL",
                column: "IDSKILL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEVELOPER_SKILL");

            migrationBuilder.DropTable(
                name: "PROJECT_SKILL");

            migrationBuilder.DropTable(
                name: "DEVELOPER");

            migrationBuilder.DropTable(
                name: "PROJECT");

            migrationBuilder.DropTable(
                name: "SKILL");
        }
    }
}
