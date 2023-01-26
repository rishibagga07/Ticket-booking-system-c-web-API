using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking_system.Migrations
{
    public partial class addclmroleid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "roles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "roles");
        }
    }
}
