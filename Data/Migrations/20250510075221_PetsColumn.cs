using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAppMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class PetsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pets",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pets",
                table: "Properties");
        }
    }
}
