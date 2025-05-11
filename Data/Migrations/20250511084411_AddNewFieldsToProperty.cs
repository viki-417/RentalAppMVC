using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAppMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AC",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Balcony",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Furnitured",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Garage",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tv",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Wifi",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AC",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Balcony",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Furnitured",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Garage",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Tv",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "Properties");
        }
    }
}
