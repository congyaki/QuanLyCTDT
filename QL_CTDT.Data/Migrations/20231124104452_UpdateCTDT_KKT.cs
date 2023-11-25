using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_CTDT.Data.Migrations
{
    public partial class UpdateCTDT_KKT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenCTDT_KKT",
                table: "CTDT_KKTs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CTDT_KKTs",
                keyColumn: "MaCTDT_KKT",
                keyValue: "CTDT_KKT1",
                column: "TenCTDT_KKT",
                value: "CTDT1_KKT1");

            migrationBuilder.UpdateData(
                table: "CTDT_KKTs",
                keyColumn: "MaCTDT_KKT",
                keyValue: "CTDT_KKT2",
                column: "TenCTDT_KKT",
                value: "CTDT2_KKT1");

            migrationBuilder.UpdateData(
                table: "KhoaHocs",
                keyColumn: "MaKhoaHoc",
                keyValue: "KH1",
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 11, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8772), new DateTime(2023, 12, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "KhoaHocs",
                keyColumn: "MaKhoaHoc",
                keyValue: "KH2",
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 11, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8787), new DateTime(2023, 12, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8788) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenCTDT_KKT",
                table: "CTDT_KKTs");

            migrationBuilder.UpdateData(
                table: "KhoaHocs",
                keyColumn: "MaKhoaHoc",
                keyValue: "KH1",
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 11, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3490), new DateTime(2023, 12, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3504) });

            migrationBuilder.UpdateData(
                table: "KhoaHocs",
                keyColumn: "MaKhoaHoc",
                keyValue: "KH2",
                columns: new[] { "NgayBatDau", "NgayKetThuc" },
                values: new object[] { new DateTime(2023, 11, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3511), new DateTime(2023, 12, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3511) });
        }
    }
}
