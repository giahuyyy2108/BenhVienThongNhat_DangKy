using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace BenhVienThongNhat_DangKy.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GioiTinh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioiTinh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Khu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    id_khu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Khoa_Khu_id_khu",
                        column: x => x.id_khu,
                        principalTable: "Khu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    sceensize = table.Column<string>(type: "text", nullable: true),
                    scrolltime = table.Column<string>(type: "text", nullable: true),
                    id_khoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phong_Khoa_id_khoa",
                        column: x => x.id_khoa,
                        principalTable: "Khoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenhNhan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    hoten = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    namsinh = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    mabn = table.Column<string>(type: "text", nullable: false),
                    sothe = table.Column<string>(type: "text", nullable: true),
                    id_gioitinh = table.Column<int>(type: "int", nullable: false),
                    id_phong = table.Column<int>(type: "int", nullable: false),
                    thoigian = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenhNhan", x => x.id);
                    table.ForeignKey(
                        name: "FK_BenhNhan_GioiTinh_id_gioitinh",
                        column: x => x.id_gioitinh,
                        principalTable: "GioiTinh",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenhNhan_Phong_id_phong",
                        column: x => x.id_phong,
                        principalTable: "Phong",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenhNhan_id_gioitinh",
                table: "BenhNhan",
                column: "id_gioitinh");

            migrationBuilder.CreateIndex(
                name: "IX_BenhNhan_id_phong",
                table: "BenhNhan",
                column: "id_phong");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_id_khu",
                table: "Khoa",
                column: "id_khu");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_id_khoa",
                table: "Phong",
                column: "id_khoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenhNhan");

            migrationBuilder.DropTable(
                name: "GioiTinh");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Khu");
        }
    }
}
