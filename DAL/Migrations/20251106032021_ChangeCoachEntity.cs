using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCoachEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Coaches",
                newName: "CertificateNumber");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceYears",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CoachId",
                table: "Students",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CoachId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Coaches");

            migrationBuilder.RenameColumn(
                name: "CertificateNumber",
                table: "Coaches",
                newName: "Specialty");
        }
    }
}
