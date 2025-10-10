using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addDbSetStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollment_GymClass_GymClassId",
                table: "ClassEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollment_Student_StudentId",
                table: "ClassEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_People_PersonId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_GymClass_Coach_CoachId",
                table: "GymClass");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_People_PersonId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymClass",
                table: "GymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassEnrollment",
                table: "ClassEnrollment");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "GymClass",
                newName: "GymClasses");

            migrationBuilder.RenameTable(
                name: "Coach",
                newName: "Coaches");

            migrationBuilder.RenameTable(
                name: "ClassEnrollment",
                newName: "ClassEnrollments");

            migrationBuilder.RenameIndex(
                name: "IX_Student_PersonId",
                table: "Students",
                newName: "IX_Students_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_GymClass_CoachId",
                table: "GymClasses",
                newName: "IX_GymClasses_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_Coach_PersonId",
                table: "Coaches",
                newName: "IX_Coaches_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassEnrollment_StudentId",
                table: "ClassEnrollments",
                newName: "IX_ClassEnrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassEnrollment_GymClassId",
                table: "ClassEnrollments",
                newName: "IX_ClassEnrollments_GymClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymClasses",
                table: "GymClasses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassEnrollments",
                table: "ClassEnrollments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymClasses_CategoryId",
                table: "GymClasses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_GymClasses_GymClassId",
                table: "ClassEnrollments",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_Students_StudentId",
                table: "ClassEnrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_People_PersonId",
                table: "Coaches",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymClasses_Categories_CategoryId",
                table: "GymClasses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymClasses_Coaches_CoachId",
                table: "GymClasses",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_People_PersonId",
                table: "Students",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_GymClasses_GymClassId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_Students_StudentId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_People_PersonId",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_GymClasses_Categories_CategoryId",
                table: "GymClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GymClasses_Coaches_CoachId",
                table: "GymClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_People_PersonId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymClasses",
                table: "GymClasses");

            migrationBuilder.DropIndex(
                name: "IX_GymClasses_CategoryId",
                table: "GymClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassEnrollments",
                table: "ClassEnrollments");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "GymClasses",
                newName: "GymClass");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coach");

            migrationBuilder.RenameTable(
                name: "ClassEnrollments",
                newName: "ClassEnrollment");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PersonId",
                table: "Student",
                newName: "IX_Student_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_GymClasses_CoachId",
                table: "GymClass",
                newName: "IX_GymClass_CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_Coaches_PersonId",
                table: "Coach",
                newName: "IX_Coach_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassEnrollments_StudentId",
                table: "ClassEnrollment",
                newName: "IX_ClassEnrollment_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassEnrollments_GymClassId",
                table: "ClassEnrollment",
                newName: "IX_ClassEnrollment_GymClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymClass",
                table: "GymClass",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassEnrollment",
                table: "ClassEnrollment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollment_GymClass_GymClassId",
                table: "ClassEnrollment",
                column: "GymClassId",
                principalTable: "GymClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollment_Student_StudentId",
                table: "ClassEnrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_People_PersonId",
                table: "Coach",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymClass_Coach_CoachId",
                table: "GymClass",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_People_PersonId",
                table: "Student",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
