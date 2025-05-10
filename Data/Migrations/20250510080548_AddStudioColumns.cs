using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAppMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudioColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Studio_FloorNumber",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Studio_HasElevator",
                table: "Properties",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Studio_FloorNumber",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Studio_HasElevator",
                table: "Properties");
        }
    }
}
