using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreDemo.Migrations
{
    public partial class Create_Table_QuanLyNV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuanLyNVs",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "TEXT", nullable: false),
                    TenPhongBan = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyNVs", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_QuanLyNVs_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyNVs_EmployeeID",
                table: "QuanLyNVs",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanLyNVs");
        }
    }
}
