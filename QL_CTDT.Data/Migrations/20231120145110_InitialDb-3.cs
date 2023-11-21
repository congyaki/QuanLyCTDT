using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_CTDT.Data.Migrations
{
    public partial class InitialDb3 : Migration
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
                name: "HocPhans",
                columns: table => new
                {
                    MaHocPhan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "ChuongTrinhDaoTaos",
                columns: table => new
                {
                    MaCTDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhoaHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNganh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoNamDaoTao = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhDaoTaos", x => x.MaCTDT);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDaoTaos_KhoaHocs_MaKhoaHoc",
                        column: x => x.MaKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "MaKhoaHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDaoTaos_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa");
                    table.ForeignKey(
                        name: "FK_ChuongTrinhDaoTaos_Nganhs_MaNganh",
                        column: x => x.MaNganh,
                        principalTable: "Nganhs",
                        principalColumn: "MaNganh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTDT_KKTs",
                columns: table => new
                {
                    MaCTDT_KKT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCTDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKKT = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTDT_KKTs", x => x.MaCTDT_KKT);
                    table.ForeignKey(
                        name: "FK_CTDT_KKTs_ChuongTrinhDaoTaos_MaCTDT",
                        column: x => x.MaCTDT,
                        principalTable: "ChuongTrinhDaoTaos",
                        principalColumn: "MaCTDT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTDT_KKTs_KhoiKienThucs_MaKKT",
                        column: x => x.MaKKT,
                        principalTable: "KhoiKienThucs",
                        principalColumn: "MaKKT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GanHocPhans",
                columns: table => new
                {
                    MaCTDT_KKT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHocPhan = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GanHocPhans", x => new { x.MaCTDT_KKT, x.MaHocPhan });
                    table.ForeignKey(
                        name: "FK_GanHocPhans_CTDT_KKTs_MaCTDT_KKT",
                        column: x => x.MaCTDT_KKT,
                        principalTable: "CTDT_KKTs",
                        principalColumn: "MaCTDT_KKT");
                    table.ForeignKey(
                        name: "FK_GanHocPhans_HocPhans_MaHocPhan",
                        column: x => x.MaHocPhan,
                        principalTable: "HocPhans",
                        principalColumn: "MaHocPhan");
                });

            migrationBuilder.InsertData(
                table: "KhoaHocs",
                columns: new[] { "MaKhoaHoc", "MoTa", "NgayBatDau", "NgayKetThuc", "Ten" },
                values: new object[,]
                {
                    { "KH1", "Mô tả khóa học Kỹ thuật phần mềm", new DateTime(2023, 11, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3490), new DateTime(2023, 12, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3504), "Khóa học Kỹ thuật phần mềm" },
                    { "KH2", "Mô tả khóa học Quản trị kinh doanh", new DateTime(2023, 11, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3511), new DateTime(2023, 12, 20, 21, 51, 9, 898, DateTimeKind.Local).AddTicks(3511), "Khóa học Quản trị kinh doanh" }
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
                table: "HocPhans",
                columns: new[] { "MaHocPhan", "MaKhoa", "MoTa", "SoTinChi", "Ten" },
                values: new object[,]
                {
                    { "HP1", "K1", "Mô tả học phần Lập trình C++", 3, "Lập trình C++" },
                    { "HP2", "K2", "Mô tả học phần Kế toán tài chính", 3, "Kế toán tài chính" }
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
                table: "ChuongTrinhDaoTaos",
                columns: new[] { "MaCTDT", "MaKhoa", "MaKhoaHoc", "MaNganh", "SoNamDaoTao", "Ten" },
                values: new object[] { "CTDT1", "K1", "KH1", "N1", 2f, "CTDT1" });

            migrationBuilder.InsertData(
                table: "ChuongTrinhDaoTaos",
                columns: new[] { "MaCTDT", "MaKhoa", "MaKhoaHoc", "MaNganh", "SoNamDaoTao", "Ten" },
                values: new object[] { "CTDT2", "K1", "KH1", "N1", 2f, "CTDT2" });

            migrationBuilder.InsertData(
                table: "CTDT_KKTs",
                columns: new[] { "MaCTDT_KKT", "MaCTDT", "MaKKT" },
                values: new object[] { "CTDT_KKT1", "CTDT1", "KKT1" });

            migrationBuilder.InsertData(
                table: "CTDT_KKTs",
                columns: new[] { "MaCTDT_KKT", "MaCTDT", "MaKKT" },
                values: new object[] { "CTDT_KKT2", "CTDT1", "KKT2" });

            migrationBuilder.InsertData(
                table: "GanHocPhans",
                columns: new[] { "MaCTDT_KKT", "MaHocPhan" },
                values: new object[] { "CTDT_KKT1", "HP1" });

            migrationBuilder.InsertData(
                table: "GanHocPhans",
                columns: new[] { "MaCTDT_KKT", "MaHocPhan" },
                values: new object[] { "CTDT_KKT2", "HP2" });

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhDaoTaos_MaKhoa",
                table: "ChuongTrinhDaoTaos",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhDaoTaos_MaKhoaHoc",
                table: "ChuongTrinhDaoTaos",
                column: "MaKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinhDaoTaos_MaNganh",
                table: "ChuongTrinhDaoTaos",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_CTDT_KKTs_MaCTDT",
                table: "CTDT_KKTs",
                column: "MaCTDT");

            migrationBuilder.CreateIndex(
                name: "IX_CTDT_KKTs_MaKKT",
                table: "CTDT_KKTs",
                column: "MaKKT");

            migrationBuilder.CreateIndex(
                name: "IX_GanHocPhans_MaHocPhan",
                table: "GanHocPhans",
                column: "MaHocPhan");

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
                name: "GanHocPhans");

            migrationBuilder.DropTable(
                name: "CTDT_KKTs");

            migrationBuilder.DropTable(
                name: "HocPhans");

            migrationBuilder.DropTable(
                name: "ChuongTrinhDaoTaos");

            migrationBuilder.DropTable(
                name: "KhoiKienThucs");

            migrationBuilder.DropTable(
                name: "KhoaHocs");

            migrationBuilder.DropTable(
                name: "Nganhs");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
