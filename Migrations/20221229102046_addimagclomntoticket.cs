using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking_system.Migrations
{
    public partial class addimagclomntoticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "tickets");
        }
    }
}
