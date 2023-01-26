using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking_system.Migrations
{
    public partial class modifyrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "roles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
