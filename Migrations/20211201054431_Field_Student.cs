using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreDemo.Migrations
{
    public partial class Field_Student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "Students");
        }
    }
}
