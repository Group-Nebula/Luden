using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luden.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrl_Rpg_Character : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Rpgs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Rpgs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Characters");
        }
    }
}
