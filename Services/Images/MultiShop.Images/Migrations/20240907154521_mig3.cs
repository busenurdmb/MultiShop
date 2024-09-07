using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Images.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "ImageDrives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "ImageDrives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
