using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawSuit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatesomeentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Complaints");
        }
    }
}
