using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ViewerAdminRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminRoleId",
                table: "Guilds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViewerRoleId",
                table: "Guilds",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminRoleId",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "ViewerRoleId",
                table: "Guilds");
        }
    }
}
