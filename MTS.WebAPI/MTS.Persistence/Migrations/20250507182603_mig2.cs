using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdvisorId",
                table: "Advisors",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Advisors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Advisors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Advisors",
                newName: "AdvisorId");
        }
    }
}
