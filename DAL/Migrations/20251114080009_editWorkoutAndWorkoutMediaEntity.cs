using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class editWorkoutAndWorkoutMediaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutSubCategories_WorkoutSubCategoryId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "WorkoutMedias",
                newName: "MimeType");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutSubCategoryId",
                table: "Workouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByCoachId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intensity",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Workouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PopularityScore",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryMuscleGroup",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightKg",
                table: "Workouts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutCategoryId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "WorkoutMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationSeconds",
                table: "WorkoutMedias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "WorkoutMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CreatedByCoachId",
                table: "Workouts",
                column: "CreatedByCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutCategoryId",
                table: "Workouts",
                column: "WorkoutCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Coaches_CreatedByCoachId",
                table: "Workouts",
                column: "CreatedByCoachId",
                principalTable: "Coaches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutCategories_WorkoutCategoryId",
                table: "Workouts",
                column: "WorkoutCategoryId",
                principalTable: "WorkoutCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutSubCategories_WorkoutSubCategoryId",
                table: "Workouts",
                column: "WorkoutSubCategoryId",
                principalTable: "WorkoutSubCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Coaches_CreatedByCoachId",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutCategories_WorkoutCategoryId",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutSubCategories_WorkoutSubCategoryId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_CreatedByCoachId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_WorkoutCategoryId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CreatedByCoachId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "PopularityScore",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "PrimaryMuscleGroup",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WeightKg",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutCategoryId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "WorkoutMedias");

            migrationBuilder.DropColumn(
                name: "DurationSeconds",
                table: "WorkoutMedias");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "WorkoutMedias");

            migrationBuilder.RenameColumn(
                name: "MimeType",
                table: "WorkoutMedias",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutSubCategoryId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutSubCategories_WorkoutSubCategoryId",
                table: "Workouts",
                column: "WorkoutSubCategoryId",
                principalTable: "WorkoutSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
