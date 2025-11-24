using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkoutlogEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "WorkoutLogs",
                newName: "PerformedAt");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "WorkoutLogs",
                newName: "IsCompleted");

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "WorkoutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "WorkoutLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "WorkoutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "WorkoutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "WorkoutLogs",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "WorkoutLogs");

            migrationBuilder.RenameColumn(
                name: "PerformedAt",
                table: "WorkoutLogs",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "WorkoutLogs",
                newName: "Completed");
        }
    }
}
