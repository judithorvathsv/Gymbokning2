using Microsoft.EntityFrameworkCore.Migrations;

namespace Gymbokning.Migrations
{
    public partial class IsBookedToGymClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "GymClass",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "GymClass");
        }
    }
}
