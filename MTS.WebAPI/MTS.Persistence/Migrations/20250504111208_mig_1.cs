using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "ThesisTopics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DefenseDate",
                table: "ThesisTopics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "ThesisTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ThesisTopics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "ThesisTopics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Advisors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ThesisJuryMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisId = table.Column<int>(type: "int", nullable: false),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    ThesisTopicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisJuryMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesisJuryMember_ThesisTopics_ThesisTopicId",
                        column: x => x.ThesisTopicId,
                        principalTable: "ThesisTopics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesisTopics_AdvisorId",
                table: "ThesisTopics",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisTopics_StudentId",
                table: "ThesisTopics",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisJuryMember_ThesisTopicId",
                table: "ThesisJuryMember",
                column: "ThesisTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesisTopics_Advisors_AdvisorId",
                table: "ThesisTopics",
                column: "AdvisorId",
                principalTable: "Advisors",
                principalColumn: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesisTopics_Students_StudentId",
                table: "ThesisTopics",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesisTopics_Advisors_AdvisorId",
                table: "ThesisTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_ThesisTopics_Students_StudentId",
                table: "ThesisTopics");

            migrationBuilder.DropTable(
                name: "ThesisJuryMember");

            migrationBuilder.DropIndex(
                name: "IX_ThesisTopics_AdvisorId",
                table: "ThesisTopics");

            migrationBuilder.DropIndex(
                name: "IX_ThesisTopics_StudentId",
                table: "ThesisTopics");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "ThesisTopics");

            migrationBuilder.DropColumn(
                name: "DefenseDate",
                table: "ThesisTopics");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "ThesisTopics");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ThesisTopics");

            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "ThesisTopics");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Advisors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");
        }
    }
}
