using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addUserMembershipRepostory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMembership_Memberships_MembershipId",
                table: "UserMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMembership_People_PersonId",
                table: "UserMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMembership_User_UserId",
                table: "UserMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMembership",
                table: "UserMembership");

            migrationBuilder.RenameTable(
                name: "UserMembership",
                newName: "UserMemberships");

            migrationBuilder.RenameIndex(
                name: "IX_UserMembership_UserId",
                table: "UserMemberships",
                newName: "IX_UserMemberships_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMembership_PersonId",
                table: "UserMemberships",
                newName: "IX_UserMemberships_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMembership_MembershipId",
                table: "UserMemberships",
                newName: "IX_UserMemberships_MembershipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMemberships",
                table: "UserMemberships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberships_Memberships_MembershipId",
                table: "UserMemberships",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberships_People_PersonId",
                table: "UserMemberships",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberships_User_UserId",
                table: "UserMemberships",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberships_Memberships_MembershipId",
                table: "UserMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberships_People_PersonId",
                table: "UserMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberships_User_UserId",
                table: "UserMemberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMemberships",
                table: "UserMemberships");

            migrationBuilder.RenameTable(
                name: "UserMemberships",
                newName: "UserMembership");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberships_UserId",
                table: "UserMembership",
                newName: "IX_UserMembership_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberships_PersonId",
                table: "UserMembership",
                newName: "IX_UserMembership_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMemberships_MembershipId",
                table: "UserMembership",
                newName: "IX_UserMembership_MembershipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMembership",
                table: "UserMembership",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMembership_Memberships_MembershipId",
                table: "UserMembership",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMembership_People_PersonId",
                table: "UserMembership",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMembership_User_UserId",
                table: "UserMembership",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
