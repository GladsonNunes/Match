using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Match.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MATCH_NOTIFICATION",
                columns: table => new
                {
                    IDNOTIFICATION = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MESSAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NOTIFICATION_TYPE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IDDEVELOPER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IDPROJECT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATE_CREATED = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    READ_STATUS = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCH_NOTIFICATION", x => x.IDNOTIFICATION);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MATCH_NOTIFICATION");
        }
    }
}
