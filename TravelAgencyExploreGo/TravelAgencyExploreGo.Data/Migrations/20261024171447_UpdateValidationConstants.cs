using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgencyExploreGo.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValidationConstants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "ImageUrl3",
                table: "Trips",
                newName: "Image2");

            migrationBuilder.RenameColumn(
                name: "ImageUrl2",
                table: "Trips",
                newName: "Image1");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Trips",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trips",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Destinations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image2",
                table: "Trips",
                newName: "ImageUrl3");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Trips",
                newName: "ImageUrl2");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Trips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trips",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "Trips",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Destinations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
