using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Tuyenduong",
                columns: table => new
                {
                    TuyenDuongId = table.Column<int>(type: "int", nullable: false),
                    QuangDuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nhaxe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thoigian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Tuyenduong", x => x.TuyenDuongId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Xe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenXe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BienSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTrong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuyenDuongId = table.Column<int>(type: "int", nullable: true),
                    CarImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Xe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Xe_tb_Tuyenduong_TuyenDuongId",
                        column: x => x.TuyenDuongId,
                        principalTable: "tb_Tuyenduong",
                        principalColumn: "TuyenDuongId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Xe_TuyenDuongId",
                table: "tb_Xe",
                column: "TuyenDuongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Xe");

            migrationBuilder.DropTable(
                name: "tb_Tuyenduong");
        }
    }
}
