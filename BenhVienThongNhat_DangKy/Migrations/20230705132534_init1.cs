using Microsoft.EntityFrameworkCore.Migrations;

namespace BenhVienThongNhat_DangKy.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BenhNhan_Phong_id_phong",
                table: "BenhNhan");

            migrationBuilder.AlterColumn<int>(
                name: "id_phong",
                table: "BenhNhan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BenhNhan_Phong_id_phong",
                table: "BenhNhan",
                column: "id_phong",
                principalTable: "Phong",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BenhNhan_Phong_id_phong",
                table: "BenhNhan");

            migrationBuilder.AlterColumn<int>(
                name: "id_phong",
                table: "BenhNhan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BenhNhan_Phong_id_phong",
                table: "BenhNhan",
                column: "id_phong",
                principalTable: "Phong",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
