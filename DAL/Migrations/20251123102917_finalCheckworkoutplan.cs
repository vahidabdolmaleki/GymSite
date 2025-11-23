using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class finalCheckworkoutplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_Students_StudentId",
                table: "WorkoutPlans");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "WorkoutPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_WorkoutPlans_Students_StudentId",
                table: "WorkoutPlans");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "WorkoutPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_Students_StudentId",
                table: "WorkoutPlans",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
