using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_Booking_system.Migrations
{
    public partial class Isdeletecolmtodep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "departments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "departments");
        }
    }
}
