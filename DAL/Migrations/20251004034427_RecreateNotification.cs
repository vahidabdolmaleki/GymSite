using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RecreateNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_People_personId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "Notifications",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_personId",
                table: "Notifications",
                newName: "IX_Notifications_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "AttachmentUrl",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceId",
                table: "Notifications",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Devices_DeviceId",
                table: "Notifications",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_People_PersonId",
                table: "Notifications",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Devices_DeviceId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_People_PersonId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_DeviceId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AttachmentUrl",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Notifications",
                newName: "personId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_PersonId",
                table: "Notifications",
                newName: "IX_Notifications_personId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_People_personId",
                table: "Notifications",
                column: "personId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
