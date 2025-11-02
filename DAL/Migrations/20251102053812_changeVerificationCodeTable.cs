using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeVerificationCodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Target",
                table: "VerificationCodes");

            migrationBuilder.RenameColumn(
                name: "Expiration",
                table: "VerificationCodes",
                newName: "ExpireAt");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "VerificationCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_PersonId",
                table: "VerificationCodes",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_VerificationCodes_People_PersonId",
                table: "VerificationCodes",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VerificationCodes_People_PersonId",
                table: "VerificationCodes");

            migrationBuilder.DropIndex(
                name: "IX_VerificationCodes_PersonId",
                table: "VerificationCodes");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "VerificationCodes");

            migrationBuilder.RenameColumn(
                name: "ExpireAt",
                table: "VerificationCodes",
                newName: "Expiration");

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "VerificationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
