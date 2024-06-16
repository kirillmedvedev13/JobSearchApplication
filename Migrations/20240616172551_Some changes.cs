using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchApplication.Migrations
{
    /// <inheritdoc />
    public partial class Somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedRoleId",
                table: "Applications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedRoleId",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
