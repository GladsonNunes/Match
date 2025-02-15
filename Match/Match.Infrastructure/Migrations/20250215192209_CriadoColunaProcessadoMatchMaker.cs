using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Match.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriadoColunaProcessadoMatchMaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "STATUS_PROCESSED_MATCH_MAKER)",
                table: "MATCH_MAKER",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STATUS_PROCESSED_MATCH_MAKER)",
                table: "MATCH_MAKER");
        }
    }
}
