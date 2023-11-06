using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_CTDT.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.MaKhoaHoc);
                });

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "KhoiKienThucs",
                columns: table => new
                {
                    MaKKT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoiKienThucs", x => x.MaKKT);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucCTDTs",
                columns: table => new
                {
                    MaDanhMucCTDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucCTDTs", x => x.MaDanhMucCTDT);
                    table.ForeignKey(
                        name: "FK_DanhMucCTDTs_KhoaHocs_MaKhoaHoc",
                        column: x => x.MaKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "MaKhoaHoc");
                    table.ForeignKey(
                        name: "FK_DanhMucCTDTs_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "Nganhs",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganhs", x => x.MaNganh);
                    table.ForeignKey(
                        name: "FK_Nganhs_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocPhans",
                columns: table => new
                {
                    MaHocPhan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhoiKienThucMaKKT = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhans", x => x.MaHocPhan);
                    table.ForeignKey(
                        name: "FK_HocPhans_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocPhans_KhoiKienThucs_KhoiKienThucMaKKT",
                        column: x => x.KhoiKienThucMaKKT,
                        principalTable: "KhoiKienThucs",
                        principalColumn: "MaKKT");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucCTDT_KKTs",
                columns: table => new
                {
                    MaDanhMucCTDT_KKT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDanhMucCTDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKKT = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucCTDT_KKTs", x => x.MaDanhMucCTDT_KKT);
                    table.ForeignKey(
                        name: "FK_DanhMucCTDT_KKTs_DanhMucCTDTs_MaDanhMucCTDT",
                        column: x => x.MaDanhMucCTDT,
                        principalTable: "DanhMucCTDTs",
                        principalColumn: "MaDanhMucCTDT");
                    table.ForeignKey(
                        name: "FK_DanhMucCTDT_KKTs_KhoiKienThucs_MaKKT",
                        column: x => x.MaKKT,
                        principalTable: "KhoiKienThucs",
                        principalColumn: "MaKKT");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCTDTs",
                columns: table => new
                {
                    MaChiTietCTDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHocPhan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDanhMucCTDT_KKT = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCTDTs", x => x.MaChiTietCTDT);
                    table.ForeignKey(
                        name: "FK_ChiTietCTDTs_DanhMucCTDT_KKTs_MaDanhMucCTDT_KKT",
                        column: x => x.MaDanhMucCTDT_KKT,
                        principalTable: "DanhMucCTDT_KKTs",
                        principalColumn: "MaDanhMucCTDT_KKT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietCTDTs_HocPhans_MaHocPhan",
                        column: x => x.MaHocPhan,
                        principalTable: "HocPhans",
                        principalColumn: "MaHocPhan");
                });

            migrationBuilder.InsertData(
                table: "KhoaHocs",
                columns: new[] { "MaKhoaHoc", "MoTa", "NgayBatDau", "NgayKetThuc", "Ten" },
                values: new object[,]
                {
                    { "KH1", "Mô tả khóa học Kỹ thuật phần mềm", new DateTime(2023, 11, 6, 21, 48, 1, 855, DateTimeKind.Local).AddTicks(9214), new DateTime(2023, 12, 6, 21, 48, 1, 855, DateTimeKind.Local).AddTicks(9226), "Khóa học Kỹ thuật phần mềm" },
                    { "KH2", "Mô tả khóa học Quản trị kinh doanh", new DateTime(2023, 11, 6, 21, 48, 1, 855, DateTimeKind.Local).AddTicks(9235), new DateTime(2023, 12, 6, 21, 48, 1, 855, DateTimeKind.Local).AddTicks(9235), "Khóa học Quản trị kinh doanh" }
                });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "MaKhoa", "MoTa", "Ten" },
                values: new object[,]
                {
                    { "K1", "Mô tả khoa Kỹ thuật", "Khoa Kỹ thuật" },
                    { "K2", "Mô tả khoa Kinh tế", "Khoa Kinh tế" }
                });

            migrationBuilder.InsertData(
                table: "KhoiKienThucs",
                columns: new[] { "MaKKT", "MoTa", "Ten" },
                values: new object[,]
                {
                    { "KKT1", "Mô tả khối kiến thức 1", "Khối kiến thức 1" },
                    { "KKT2", "Mô tả khối kiến thức 2", "Khối kiến thức 2" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucCTDTs",
                columns: new[] { "MaDanhMucCTDT", "MaKhoa", "MaKhoaHoc" },
                values: new object[,]
                {
                    { "CTDT1", "K1", "KH1" },
                    { "CTDT2", "K2", "KH2" }
                });

            migrationBuilder.InsertData(
                table: "HocPhans",
                columns: new[] { "MaHocPhan", "KhoiKienThucMaKKT", "MaKhoa", "MoTa", "SoTinChi", "Ten" },
                values: new object[,]
                {
                    { "HP1", null, "K1", "Mô tả học phần Lập trình C++", 3, "Lập trình C++" },
                    { "HP2", null, "K2", "Mô tả học phần Kế toán tài chính", 3, "Kế toán tài chính" }
                });

            migrationBuilder.InsertData(
                table: "Nganhs",
                columns: new[] { "MaNganh", "MaKhoa", "MoTa", "Ten" },
                values: new object[,]
                {
                    { "N1", "K1", "Mô tả ngành Công nghệ thông tin", "Ngành Công nghệ thông tin" },
                    { "N2", "K2", "Mô tả ngành Kế toán", "Ngành Kế toán" }
                });

            migrationBuilder.InsertData(
                table: "DanhMucCTDT_KKTs",
                columns: new[] { "MaDanhMucCTDT_KKT", "MaDanhMucCTDT", "MaKKT" },
                values: new object[] { "CTDT_KKT_1", "CTDT1", "KKT1" });

            migrationBuilder.InsertData(
                table: "DanhMucCTDT_KKTs",
                columns: new[] { "MaDanhMucCTDT_KKT", "MaDanhMucCTDT", "MaKKT" },
                values: new object[] { "CTDT_KKT_2", "CTDT1", "KKT2" });

            migrationBuilder.InsertData(
                table: "ChiTietCTDTs",
                columns: new[] { "MaChiTietCTDT", "MaDanhMucCTDT_KKT", "MaHocPhan" },
                values: new object[] { "1", "CTDT_KKT_1", "HP1" });

            migrationBuilder.InsertData(
                table: "ChiTietCTDTs",
                columns: new[] { "MaChiTietCTDT", "MaDanhMucCTDT_KKT", "MaHocPhan" },
                values: new object[] { "2", "CTDT_KKT_2", "HP2" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCTDTs_MaDanhMucCTDT_KKT",
                table: "ChiTietCTDTs",
                column: "MaDanhMucCTDT_KKT");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCTDTs_MaHocPhan",
                table: "ChiTietCTDTs",
                column: "MaHocPhan");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCTDT_KKTs_MaDanhMucCTDT",
                table: "DanhMucCTDT_KKTs",
                column: "MaDanhMucCTDT");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCTDT_KKTs_MaKKT",
                table: "DanhMucCTDT_KKTs",
                column: "MaKKT");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCTDTs_MaKhoa",
                table: "DanhMucCTDTs",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCTDTs_MaKhoaHoc",
                table: "DanhMucCTDTs",
                column: "MaKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhans_KhoiKienThucMaKKT",
                table: "HocPhans",
                column: "KhoiKienThucMaKKT");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhans_MaKhoa",
                table: "HocPhans",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_Nganhs_MaKhoa",
                table: "Nganhs",
                column: "MaKhoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietCTDTs");

            migrationBuilder.DropTable(
                name: "Nganhs");

            migrationBuilder.DropTable(
                name: "DanhMucCTDT_KKTs");

            migrationBuilder.DropTable(
                name: "HocPhans");

            migrationBuilder.DropTable(
                name: "DanhMucCTDTs");

            migrationBuilder.DropTable(
                name: "KhoiKienThucs");

            migrationBuilder.DropTable(
                name: "KhoaHocs");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
