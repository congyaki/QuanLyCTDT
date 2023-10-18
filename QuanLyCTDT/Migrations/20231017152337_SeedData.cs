using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCTDT.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "KhoaID", "MoTa", "TenKhoa" },
                values: new object[] { 1, "Khoa Công nghệ thông tin", "Khoa Công nghệ thông tin" });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "KhoaID", "MoTa", "TenKhoa" },
                values: new object[] { 2, "Khoa Kinh tế", "Khoa Kinh tế" });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "KhoaID", "MoTa", "TenKhoa" },
                values: new object[] { 3, "Khoa Quản trị kinh doanh", "Khoa Quản trị kinh doanh" });

            migrationBuilder.InsertData(
                table: "Nganhs",
                columns: new[] { "NganhID", "KhoaID", "MoTa", "TenNganh" },
                values: new object[,]
                {
                    { 1, 1, "Ngành Công nghệ thông tin", "Công nghệ thông tin" },
                    { 2, 1, "Ngành Hệ thống thông tin", "Hệ thống thông tin" },
                    { 3, 2, "Ngành Kế toán", "Kế toán" },
                    { 4, 3, "Ngành Marketing", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "KhoaHocs",
                columns: new[] { "KhoaHocID", "MoTa", "NganhID", "NgayBatDau", "NgayKetThuc", "TenKhoaHoc" },
                values: new object[,]
                {
                    { 1, "Khóa học lập trình C#", 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình C#" },
                    { 2, "Khóa học quản lý dự án", 2, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quản lý dự án" },
                    { 3, "Khóa học kế toán tài chính", 3, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kế toán tài chính" },
                    { 4, "Khóa học Digital Marketing", 4, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digital Marketing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KhoaHocs",
                keyColumn: "KhoaHocID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KhoaHocs",
                keyColumn: "KhoaHocID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KhoaHocs",
                keyColumn: "KhoaHocID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KhoaHocs",
                keyColumn: "KhoaHocID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nganhs",
                keyColumn: "NganhID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nganhs",
                keyColumn: "NganhID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nganhs",
                keyColumn: "NganhID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nganhs",
                keyColumn: "NganhID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "KhoaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "KhoaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Khoas",
                keyColumn: "KhoaID",
                keyValue: 3);
        }
    }
}
