﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QL_CTDT.Data.Models.EF;

#nullable disable

namespace QL_CTDT.Data.Migrations
{
    [DbContext(typeof(TrainingProgramDbContext))]
    partial class TrainingProgramDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.ChuongTrinhDaoTao", b =>
                {
                    b.Property<string>("MaCTDT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoaHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("SoNamDaoTao")
                        .HasColumnType("real");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCTDT");

                    b.HasIndex("MaKhoa");

                    b.HasIndex("MaKhoaHoc");

                    b.HasIndex("MaNganh");

                    b.ToTable("ChuongTrinhDaoTaos");

                    b.HasData(
                        new
                        {
                            MaCTDT = "CTDT1",
                            MaKhoa = "K1",
                            MaKhoaHoc = "KH1",
                            MaNganh = "N1",
                            SoNamDaoTao = 2f,
                            Ten = "CTDT1"
                        },
                        new
                        {
                            MaCTDT = "CTDT2",
                            MaKhoa = "K1",
                            MaKhoaHoc = "KH1",
                            MaNganh = "N1",
                            SoNamDaoTao = 2f,
                            Ten = "CTDT2"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.CTDT_KKT", b =>
                {
                    b.Property<string>("MaCTDT_KKT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaCTDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKKT")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenCTDT_KKT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCTDT_KKT");

                    b.HasIndex("MaCTDT");

                    b.HasIndex("MaKKT");

                    b.ToTable("CTDT_KKTs");

                    b.HasData(
                        new
                        {
                            MaCTDT_KKT = "CTDT_KKT1",
                            MaCTDT = "CTDT1",
                            MaKKT = "KKT1",
                            TenCTDT_KKT = "CTDT1_KKT1"
                        },
                        new
                        {
                            MaCTDT_KKT = "CTDT_KKT2",
                            MaCTDT = "CTDT1",
                            MaKKT = "KKT2",
                            TenCTDT_KKT = "CTDT2_KKT1"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.GanHocPhan", b =>
                {
                    b.Property<string>("MaCTDT_KKT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaHocPhan")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaCTDT_KKT", "MaHocPhan");

                    b.HasIndex("MaHocPhan");

                    b.ToTable("GanHocPhans");

                    b.HasData(
                        new
                        {
                            MaCTDT_KKT = "CTDT_KKT1",
                            MaHocPhan = "HP1"
                        },
                        new
                        {
                            MaCTDT_KKT = "CTDT_KKT2",
                            MaHocPhan = "HP2"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.HocPhan", b =>
                {
                    b.Property<string>("MaHocPhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoTinChi")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHocPhan");

                    b.HasIndex("MaKhoa");

                    b.ToTable("HocPhans");

                    b.HasData(
                        new
                        {
                            MaHocPhan = "HP1",
                            MaKhoa = "K1",
                            MoTa = "Mô tả học phần Lập trình C++",
                            SoTinChi = 3,
                            Ten = "Lập trình C++"
                        },
                        new
                        {
                            MaHocPhan = "HP2",
                            MaKhoa = "K2",
                            MoTa = "Mô tả học phần Kế toán tài chính",
                            SoTinChi = 3,
                            Ten = "Kế toán tài chính"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.Khoa", b =>
                {
                    b.Property<string>("MaKhoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoas");

                    b.HasData(
                        new
                        {
                            MaKhoa = "K1",
                            MoTa = "Mô tả khoa Kỹ thuật",
                            Ten = "Khoa Kỹ thuật"
                        },
                        new
                        {
                            MaKhoa = "K2",
                            MoTa = "Mô tả khoa Kinh tế",
                            Ten = "Khoa Kinh tế"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.KhoaHoc", b =>
                {
                    b.Property<string>("MaKhoaHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhoaHoc");

                    b.ToTable("KhoaHocs");

                    b.HasData(
                        new
                        {
                            MaKhoaHoc = "KH1",
                            MoTa = "Mô tả khóa học Kỹ thuật phần mềm",
                            NgayBatDau = new DateTime(2023, 11, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8772),
                            NgayKetThuc = new DateTime(2023, 12, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8781),
                            Ten = "Khóa học Kỹ thuật phần mềm"
                        },
                        new
                        {
                            MaKhoaHoc = "KH2",
                            MoTa = "Mô tả khóa học Quản trị kinh doanh",
                            NgayBatDau = new DateTime(2023, 11, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8787),
                            NgayKetThuc = new DateTime(2023, 12, 24, 17, 44, 51, 757, DateTimeKind.Local).AddTicks(8788),
                            Ten = "Khóa học Quản trị kinh doanh"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.KhoiKienThuc", b =>
                {
                    b.Property<string>("MaKKT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKKT");

                    b.ToTable("KhoiKienThucs");

                    b.HasData(
                        new
                        {
                            MaKKT = "KKT1",
                            MoTa = "Mô tả khối kiến thức 1",
                            Ten = "Khối kiến thức 1"
                        },
                        new
                        {
                            MaKKT = "KKT2",
                            MoTa = "Mô tả khối kiến thức 2",
                            Ten = "Khối kiến thức 2"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.Nganh", b =>
                {
                    b.Property<string>("MaNganh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNganh");

                    b.HasIndex("MaKhoa");

                    b.ToTable("Nganhs");

                    b.HasData(
                        new
                        {
                            MaNganh = "N1",
                            MaKhoa = "K1",
                            MoTa = "Mô tả ngành Công nghệ thông tin",
                            Ten = "Ngành Công nghệ thông tin"
                        },
                        new
                        {
                            MaNganh = "N2",
                            MaKhoa = "K2",
                            MoTa = "Mô tả ngành Kế toán",
                            Ten = "Ngành Kế toán"
                        });
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.ChuongTrinhDaoTao", b =>
                {
                    b.HasOne("QL_CTDT.Data.Models.Entities.Khoa", "Khoa")
                        .WithMany("ChuongTrinhDaoTaos")
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QL_CTDT.Data.Models.Entities.KhoaHoc", "KhoaHoc")
                        .WithMany("ChuongTrinhDaoTaos")
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_CTDT.Data.Models.Entities.Nganh", "Nganh")
                        .WithMany("ChuongTrinhDaoTaos")
                        .HasForeignKey("MaNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");

                    b.Navigation("KhoaHoc");

                    b.Navigation("Nganh");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.CTDT_KKT", b =>
                {
                    b.HasOne("QL_CTDT.Data.Models.Entities.ChuongTrinhDaoTao", "ChuongTrinhDaoTao")
                        .WithMany("CTDT_KKTs")
                        .HasForeignKey("MaCTDT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_CTDT.Data.Models.Entities.KhoiKienThuc", "KhoiKienThuc")
                        .WithMany("CTDT_KKTs")
                        .HasForeignKey("MaKKT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChuongTrinhDaoTao");

                    b.Navigation("KhoiKienThuc");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.GanHocPhan", b =>
                {
                    b.HasOne("QL_CTDT.Data.Models.Entities.CTDT_KKT", "CTDT_KKT")
                        .WithMany("GanHocPhans")
                        .HasForeignKey("MaCTDT_KKT")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QL_CTDT.Data.Models.Entities.HocPhan", "HocPhan")
                        .WithMany("GanHocPhans")
                        .HasForeignKey("MaHocPhan")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CTDT_KKT");

                    b.Navigation("HocPhan");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.HocPhan", b =>
                {
                    b.HasOne("QL_CTDT.Data.Models.Entities.Khoa", "Khoa")
                        .WithMany("HocPhans")
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.Nganh", b =>
                {
                    b.HasOne("QL_CTDT.Data.Models.Entities.Khoa", "Khoa")
                        .WithMany("Nganhs")
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.ChuongTrinhDaoTao", b =>
                {
                    b.Navigation("CTDT_KKTs");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.CTDT_KKT", b =>
                {
                    b.Navigation("GanHocPhans");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.HocPhan", b =>
                {
                    b.Navigation("GanHocPhans");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.Khoa", b =>
                {
                    b.Navigation("ChuongTrinhDaoTaos");

                    b.Navigation("HocPhans");

                    b.Navigation("Nganhs");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.KhoaHoc", b =>
                {
                    b.Navigation("ChuongTrinhDaoTaos");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.KhoiKienThuc", b =>
                {
                    b.Navigation("CTDT_KKTs");
                });

            modelBuilder.Entity("QL_CTDT.Data.Models.Entities.Nganh", b =>
                {
                    b.Navigation("ChuongTrinhDaoTaos");
                });
#pragma warning restore 612, 618
        }
    }
}
