using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSignupSystem.Migrations
{
    public partial class das : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScheduleTeacherCode",
                table: "Schedule",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleTeacherCode",
                table: "Schedule");
        }
    }
}
