using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gymbokning.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookedGymClassViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserGymClassIsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedGymClassViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GymClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserGymClass",
                columns: table => new
                {
                    GymClassId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGymClass", x => new { x.ApplicationUserId, x.GymClassId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_GymClass_GymClassId",
                        column: x => x.GymClassId,
                        principalTable: "GymClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GymClass",
                columns: new[] { "Id", "Description", "Duration", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness).", new TimeSpan(0, 1, 30, 0, 0), "Aerobics", new DateTime(2021, 9, 2, 19, 9, 46, 578, DateTimeKind.Local).AddTicks(6395) },
                    { 30, "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance.", new TimeSpan(0, 1, 30, 0, 0), "Zumba", new DateTime(2021, 9, 7, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5966) },
                    { 29, "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it.", new TimeSpan(0, 1, 0, 0, 0), "Yoga", new DateTime(2021, 9, 13, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5963) },
                    { 28, "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise with less intense recovery periods, until too exhausted to continue. The method is not just restricted to cardio and frequently includes weights for the short periods as well.", new TimeSpan(0, 0, 30, 0, 0), "HIIT", new DateTime(2021, 10, 2, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5961) },
                    { 27, "Kickboxing is a group of stand-up combat sports based on kicking and punching, historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport.", new TimeSpan(0, 1, 0, 0, 0), "Kickboxing", new DateTime(2021, 10, 1, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5958) },
                    { 26, "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance.", new TimeSpan(0, 1, 30, 0, 0), "Pilates", new DateTime(2021, 9, 30, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5956) },
                    { 25, "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness).", new TimeSpan(0, 1, 30, 0, 0), "Aerobics", new DateTime(2021, 9, 29, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5954) },
                    { 24, "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have.", new TimeSpan(0, 0, 45, 0, 0), "Skyrobics", new DateTime(2021, 9, 28, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5951) },
                    { 23, "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. ", new TimeSpan(0, 0, 45, 0, 0), "Circuit", new DateTime(2021, 9, 27, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5949) },
                    { 22, "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance.", new TimeSpan(0, 1, 30, 0, 0), "Zumba", new DateTime(2021, 9, 7, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5947) },
                    { 21, "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it.", new TimeSpan(0, 1, 0, 0, 0), "Yoga", new DateTime(2021, 9, 13, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5945) },
                    { 20, "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise with less intense recovery periods, until too exhausted to continue. The method is not just restricted to cardio and frequently includes weights for the short periods as well.", new TimeSpan(0, 0, 30, 0, 0), "HIIT", new DateTime(2021, 9, 26, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5943) },
                    { 19, "Kickboxing is a group of stand-up combat sports based on kicking and punching, historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport.", new TimeSpan(0, 1, 0, 0, 0), "Kickboxing", new DateTime(2021, 9, 25, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5940) },
                    { 18, "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance.", new TimeSpan(0, 1, 30, 0, 0), "Pilates", new DateTime(2021, 9, 24, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5938) },
                    { 17, "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness).", new TimeSpan(0, 1, 30, 0, 0), "Aerobics", new DateTime(2021, 9, 22, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5935) },
                    { 16, "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have.", new TimeSpan(0, 0, 45, 0, 0), "Skyrobics", new DateTime(2021, 9, 15, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5933) },
                    { 15, "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. ", new TimeSpan(0, 0, 45, 0, 0), "Circuit", new DateTime(2021, 9, 14, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5931) },
                    { 14, "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance.", new TimeSpan(0, 1, 30, 0, 0), "Zumba", new DateTime(2021, 9, 7, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5929) },
                    { 13, "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it.", new TimeSpan(0, 1, 0, 0, 0), "Yoga", new DateTime(2021, 9, 13, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5927) },
                    { 12, "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise with less intense recovery periods, until too exhausted to continue. The method is not just restricted to cardio and frequently includes weights for the short periods as well.", new TimeSpan(0, 0, 30, 0, 0), "HIIT", new DateTime(2021, 9, 12, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5924) },
                    { 11, "Kickboxing is a group of stand-up combat sports based on kicking and punching, historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport.", new TimeSpan(0, 1, 0, 0, 0), "Kickboxing", new DateTime(2021, 9, 11, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5921) },
                    { 10, "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance.", new TimeSpan(0, 1, 30, 0, 0), "Pilates", new DateTime(2021, 9, 10, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5919) },
                    { 9, "Aerobics is a form of physical exercise that combines rhythmic aerobic exercise with stretching and strength training routines with the goal of improving all elements of fitness (flexibility, muscular strength, and cardio-vascular fitness).", new TimeSpan(0, 1, 30, 0, 0), "Aerobics", new DateTime(2021, 9, 9, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5917) },
                    { 8, "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have.", new TimeSpan(0, 0, 45, 0, 0), "Skyrobics", new DateTime(2021, 9, 8, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5915) },
                    { 7, "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. ", new TimeSpan(0, 0, 45, 0, 0), "Circuit", new DateTime(2021, 9, 8, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5913) },
                    { 6, "Zumba is an interval workout. The classes move between high- and low-intensity dance moves designed to get your heart rate up and boost cardio endurance.", new TimeSpan(0, 1, 30, 0, 0), "Zumba", new DateTime(2021, 9, 7, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5910) },
                    { 5, "Yoga is a mind-body practice that combines physical poses, controlled breathing, and meditation or relaxation. Yoga may help reduce stress, lower blood pressure and lower your heart rate. And almost anyone can do it.", new TimeSpan(0, 1, 0, 0, 0), "Yoga", new DateTime(2021, 9, 6, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5908) },
                    { 4, "High-intensity interval training (HIIT) is a form of interval training, a cardiovascular exercise strategy alternating short periods of intense anaerobic exercise with less intense recovery periods, until too exhausted to continue. The method is not just restricted to cardio and frequently includes weights for the short periods as well.", new TimeSpan(0, 0, 30, 0, 0), "HIIT", new DateTime(2021, 9, 5, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5906) },
                    { 3, "Kickboxing is a group of stand-up combat sports based on kicking and punching, historically developed from karate mixed with boxing. Kickboxing is practiced for self-defence, general fitness, or as a contact sport.", new TimeSpan(0, 1, 0, 0, 0), "Kickboxing", new DateTime(2021, 9, 4, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5902) },
                    { 2, "Pilates improves flexibility, builds strength and develops control and endurance in the entire body. It puts emphasis on alignment, breathing, developing a strong core, and improving coordination and balance.", new TimeSpan(0, 1, 30, 0, 0), "Pilates", new DateTime(2021, 9, 4, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5879) },
                    { 31, "Boredom and time constraints are frequently cited reasons for giving up on a fitness routine. Sound familiar? Circuit training offers a practical solution for both. It’s a creative and flexible way to keep exercise interesting and saves time while boosting cardiovascular and muscular fitness. ", new TimeSpan(0, 0, 45, 0, 0), "Circuit", new DateTime(2021, 10, 3, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5968) },
                    { 32, "Burn up to 1,000 calories while having a blast. Feel that oh-so-rewarding burn in your legs, arms, and core over an hour of fitness disguised as fun. It’s one of the most dynamic, effective, and enjoyable workouts you'll ever have.", new TimeSpan(0, 0, 45, 0, 0), "Skyrobics", new DateTime(2021, 10, 4, 19, 9, 46, 580, DateTimeKind.Local).AddTicks(5970) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGymClass_GymClassId",
                table: "ApplicationUserGymClass",
                column: "GymClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGymClass");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookedGymClassViewModel");

            migrationBuilder.DropTable(
                name: "GymClass");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
