using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStudentIdFromUsermembershipWitheDeleteCollectionInStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberships_Students_StudentId",
                table: "UserMemberships");

            migrationBuilder.DropIndex(
                name: "IX_UserMemberships_StudentId",
                table: "UserMemberships");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "UserMemberships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "UserMemberships",
                type: "int",
                nullable: true);

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
        }
    }
}
