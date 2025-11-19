using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkoutSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WorkoutSubCategories",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "WorkoutSubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkoutSubCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WorkoutSubCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkoutSubCategories");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "WorkoutSubCategories",
                newName: "Name");
        }
    }
}
