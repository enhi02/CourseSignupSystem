using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSignupSystem.Migrations
{
    public partial class dsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Course_courseModelCourseId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_User_ClassUser",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_ClassUser",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_courseModelCourseId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "courseModelCourseId",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "ClassUser",
                table: "Class",
                newName: "ClassQuantityPresent");

            migrationBuilder.AddColumn<int>(
                name: "classModelClassId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassCourse",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_classModelClassId",
                table: "User",
                column: "classModelClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_ClassCourse",
                table: "Class",
                column: "ClassCourse");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Course_ClassCourse",
                table: "Class",
                column: "ClassCourse",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Class_classModelClassId",
                table: "User",
                column: "classModelClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Course_ClassCourse",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Class_classModelClassId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_classModelClassId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Class_ClassCourse",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "classModelClassId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClassCourse",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "ClassQuantityPresent",
                table: "Class",
                newName: "ClassUser");

            migrationBuilder.AddColumn<int>(
                name: "courseModelCourseId",
                table: "Class",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_ClassUser",
                table: "Class",
                column: "ClassUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_courseModelCourseId",
                table: "Class",
                column: "courseModelCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Course_courseModelCourseId",
                table: "Class",
                column: "courseModelCourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_User_ClassUser",
                table: "Class",
                column: "ClassUser",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
