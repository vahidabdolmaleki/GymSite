using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditStudentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "WorkoutPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "UserMemberships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_StudentId",
                table: "WorkoutPlans",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberships_StudentId",
                table: "UserMemberships",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberships_Students_StudentId",
                table: "UserMemberships",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_Students_StudentId",
                table: "WorkoutPlans",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberships_Students_StudentId",
                table: "UserMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_Students_StudentId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_StudentId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_UserMemberships_StudentId",
                table: "UserMemberships");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "UserMemberships");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Students");
        }
    }
}
