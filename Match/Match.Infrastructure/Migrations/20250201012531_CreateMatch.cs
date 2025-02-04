using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Match.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StatusProcessed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TypeMatch = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DateMatch = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATCH_MAKER",
                columns: table => new
                {
                    IDMATCHMAKER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                      .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IDMATCH = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IDPROJECT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IDDEVELOPER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCH_MAKER", x => new { x.IDMATCHMAKER, x.IDMATCH });
                    table.ForeignKey(
                        name: "FK_MATCH_MAKER_Match_IDMATCH",
                        column: x => x.IDMATCH,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MATCH_MAKER_IDMATCH",
                table: "MATCH_MAKER",
                column: "IDMATCH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MATCH_MAKER");

            migrationBuilder.DropTable(
                name: "Match");
        }
    }
}
