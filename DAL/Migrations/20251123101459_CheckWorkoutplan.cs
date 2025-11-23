using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CheckWorkoutplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlanItem_WorkoutPlans_WorkoutPlanId",
                table: "WorkoutPlanItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlanItem_Workouts_WorkoutId",
                table: "WorkoutPlanItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutPlanItem",
                table: "WorkoutPlanItem");

            migrationBuilder.RenameTable(
                name: "WorkoutPlanItem",
                newName: "WorkoutPlanItems");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutPlanItem_WorkoutPlanId",
                table: "WorkoutPlanItems",
                newName: "IX_WorkoutPlanItems_WorkoutPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutPlanItem_WorkoutId",
                table: "WorkoutPlanItems",
                newName: "IX_WorkoutPlanItems_WorkoutId");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "WorkoutPlanItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutPlanItems",
                table: "WorkoutPlanItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlanItems_WorkoutPlans_WorkoutPlanId",
                table: "WorkoutPlanItems",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlanItems_Workouts_WorkoutId",
                table: "WorkoutPlanItems",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlanItems_WorkoutPlans_WorkoutPlanId",
                table: "WorkoutPlanItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlanItems_Workouts_WorkoutId",
                table: "WorkoutPlanItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutPlanItems",
                table: "WorkoutPlanItems");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "WorkoutPlanItems");

            migrationBuilder.RenameTable(
                name: "WorkoutPlanItems",
                newName: "WorkoutPlanItem");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutPlanItems_WorkoutPlanId",
                table: "WorkoutPlanItem",
                newName: "IX_WorkoutPlanItem_WorkoutPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutPlanItems_WorkoutId",
                table: "WorkoutPlanItem",
                newName: "IX_WorkoutPlanItem_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutPlanItem",
                table: "WorkoutPlanItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlanItem_WorkoutPlans_WorkoutPlanId",
                table: "WorkoutPlanItem",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlanItem_Workouts_WorkoutId",
                table: "WorkoutPlanItem",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
