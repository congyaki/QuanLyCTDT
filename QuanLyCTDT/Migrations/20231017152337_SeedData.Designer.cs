﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyCTDT.Models;

#nullable disable

namespace QuanLyCTDT.Migrations
{
    [DbContext(typeof(TrainingProgramDbContext))]
    [Migration("20231017152337_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyCTDT.Models.Khoa", b =>
                {
                    b.Property<int>("KhoaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaID"), 1L, 1);

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KhoaID");

                    b.ToTable("Khoas");

                    b.HasData(
                        new
                        {
                            KhoaID = 1,
                            MoTa = "Khoa Công nghệ thông tin",
                            TenKhoa = "Khoa Công nghệ thông tin"
                        },
                        new
                        {
                            KhoaID = 2,
                            MoTa = "Khoa Kinh tế",
                            TenKhoa = "Khoa Kinh tế"
                        },
                        new
                        {
                            KhoaID = 3,
                            MoTa = "Khoa Quản trị kinh doanh",
                            TenKhoa = "Khoa Quản trị kinh doanh"
                        });
                });

            modelBuilder.Entity("QuanLyCTDT.Models.KhoaHoc", b =>
                {
                    b.Property<int>("KhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaHocID"), 1L, 1);

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NganhID")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KhoaHocID");

                    b.HasIndex("NganhID");

                    b.ToTable("KhoaHocs");

                    b.HasData(
                        new
                        {
                            KhoaHocID = 1,
                            MoTa = "Khóa học lập trình C#",
                            NganhID = 1,
                            NgayBatDau = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayKetThuc = new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhoaHoc = "Lập trình C#"
                        },
                        new
                        {
                            KhoaHocID = 2,
                            MoTa = "Khóa học quản lý dự án",
                            NganhID = 2,
                            NgayBatDau = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayKetThuc = new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhoaHoc = "Quản lý dự án"
                        },
                        new
                        {
                            KhoaHocID = 3,
                            MoTa = "Khóa học kế toán tài chính",
                            NganhID = 3,
                            NgayBatDau = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayKetThuc = new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhoaHoc = "Kế toán tài chính"
                        },
                        new
                        {
                            KhoaHocID = 4,
                            MoTa = "Khóa học Digital Marketing",
                            NganhID = 4,
                            NgayBatDau = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayKetThuc = new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhoaHoc = "Digital Marketing"
                        });
                });

            modelBuilder.Entity("QuanLyCTDT.Models.Nganh", b =>
                {
                    b.Property<int>("NganhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NganhID"), 1L, 1);

                    b.Property<int>("KhoaID")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenNganh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NganhID");

                    b.HasIndex("KhoaID");

                    b.ToTable("Nganhs");

                    b.HasData(
                        new
                        {
                            NganhID = 1,
                            KhoaID = 1,
                            MoTa = "Ngành Công nghệ thông tin",
                            TenNganh = "Công nghệ thông tin"
                        },
                        new
                        {
                            NganhID = 2,
                            KhoaID = 1,
                            MoTa = "Ngành Hệ thống thông tin",
                            TenNganh = "Hệ thống thông tin"
                        },
                        new
                        {
                            NganhID = 3,
                            KhoaID = 2,
                            MoTa = "Ngành Kế toán",
                            TenNganh = "Kế toán"
                        },
                        new
                        {
                            NganhID = 4,
                            KhoaID = 3,
                            MoTa = "Ngành Marketing",
                            TenNganh = "Marketing"
                        });
                });

            modelBuilder.Entity("QuanLyCTDT.Models.KhoaHoc", b =>
                {
                    b.HasOne("QuanLyCTDT.Models.Nganh", "Nganh")
                        .WithMany("KhoaHocs")
                        .HasForeignKey("NganhID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nganh");
                });

            modelBuilder.Entity("QuanLyCTDT.Models.Nganh", b =>
                {
                    b.HasOne("QuanLyCTDT.Models.Khoa", "Khoa")
                        .WithMany("Nganhs")
                        .HasForeignKey("KhoaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QuanLyCTDT.Models.Khoa", b =>
                {
                    b.Navigation("Nganhs");
                });

            modelBuilder.Entity("QuanLyCTDT.Models.Nganh", b =>
                {
                    b.Navigation("KhoaHocs");
                });
#pragma warning restore 612, 618
        }
    }
}
