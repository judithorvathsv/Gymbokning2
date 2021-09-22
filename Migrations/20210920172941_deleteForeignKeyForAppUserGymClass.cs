using Microsoft.EntityFrameworkCore.Migrations;

namespace Gymbokning.Migrations
{
    public partial class deleteForeignKeyForAppUserGymClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass",
                columns: new[] { "ApplicationUserId", "GymClassId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass",
                columns: new[] { "ApplicationUserId", "GymClassId", "IsBooked" });
        }
    }
}
