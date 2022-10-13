using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSignupSystem.Migrations
{
    public partial class dbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleHoliday",
                columns: table => new
                {
                    ScheduleHolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleHolidayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleHolidayReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScheduleHolidayStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleHolidayEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleHoliday", x => x.ScheduleHolidayId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleHoliday");
        }
    }
}
