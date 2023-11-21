using Microsoft.EntityFrameworkCore;
using QL_CTDT.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.EF
{
    public class TrainingProgramDbContext : DbContext
    {
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<KhoiKienThuc> KhoiKienThucs { get; set; }
        public DbSet<HocPhan> HocPhans { get; set; }
        public DbSet<GanHocPhan> GanHocPhans { get; set; }
        public DbSet<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }
        public DbSet<CTDT_KKT> CTDT_KKTs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Cấu hình chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-AVPLSS5\\SQLEXPRESS;Initial Catalog=TrainingProgramManagementDB;User ID=sa;Password=Satrymra2003!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public TrainingProgramDbContext()
        {
        }
        public TrainingProgramDbContext(DbContextOptions<TrainingProgramDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(k => k.MaKhoa);
                entity.Property(k => k.MaKhoa);
                entity.Property(k => k.Ten).IsRequired().HasMaxLength(100);
                entity.Property(k => k.MoTa).HasMaxLength(200);
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(n => n.MaNganh);
                entity.Property(k => k.MaNganh);
                entity.Property(n => n.Ten).IsRequired().HasMaxLength(100);
                entity.Property(n => n.MoTa).HasMaxLength(200);

                entity.HasOne(n => n.Khoa)
                    .WithMany(k => k.Nganhs)
                    .HasForeignKey(n => n.MaKhoa)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.HasKey(kh => kh.MaKhoaHoc);
                entity.Property(k => k.MaKhoaHoc);
                entity.Property(kh => kh.Ten).IsRequired().HasMaxLength(100);
                entity.Property(kh => kh.MoTa).HasMaxLength(200);
                entity.Property(kh => kh.NgayBatDau).IsRequired();
                entity.Property(kh => kh.NgayKetThuc).IsRequired();
            });

            modelBuilder.Entity<KhoiKienThuc>(entity =>
            {
                entity.HasKey(k => k.MaKKT);
                entity.Property(k => k.MaKKT).IsRequired();
                entity.Property(k => k.Ten).IsRequired();
                entity.Property(k => k.MoTa);
            });

            modelBuilder.Entity<HocPhan>(entity =>
            {
                entity.HasKey(h => h.MaHocPhan);
                entity.Property(h => h.MaHocPhan).IsRequired();
                entity.Property(h => h.Ten).IsRequired();
                entity.Property(h => h.MoTa);
                entity.Property(h => h.SoTinChi).IsRequired();
                entity.Property(h => h.MaKhoa).IsRequired();

                entity.HasOne(h => h.Khoa)
                    .WithMany(k => k.HocPhans)
                    .HasForeignKey(h => h.MaKhoa);
            });
            modelBuilder.Entity<CTDT_KKT>(entity =>
            {
                entity.HasKey(h => h.MaCTDT_KKT);
                entity.HasOne(d => d.ChuongTrinhDaoTao)
                        .WithMany(d => d.CTDT_KKTs)
                        .HasForeignKey(h => h.MaCTDT);
                entity.HasOne(d => d.KhoiKienThuc)
                        .WithMany(d => d.CTDT_KKTs)
                        .HasForeignKey(h => h.MaKKT);

            });
            modelBuilder.Entity<GanHocPhan>(entity =>
            {
                entity.HasKey(h => new {h.MaCTDT_KKT, h.MaHocPhan});

                entity.HasOne(d => d.CTDT_KKT)
                    .WithMany(kh => kh.GanHocPhans)
                    .HasForeignKey(d => d.MaCTDT_KKT).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.HocPhan)
                    .WithMany(kh => kh.GanHocPhans)
                    .HasForeignKey(d => d.MaHocPhan).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ChuongTrinhDaoTao>(entity =>
            {
                entity.HasKey(h => h.MaCTDT);
                entity.HasOne(h => h.Khoa)
                    .WithMany(kh => kh.ChuongTrinhDaoTaos)
                    .HasForeignKey(h => h.MaKhoa).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(h => h.KhoaHoc)
                    .WithMany(kh => kh.ChuongTrinhDaoTaos)
                    .HasForeignKey(h => h.MaKhoaHoc);
                entity.HasOne(h => h.Nganh)
                    .WithMany(kh => kh.ChuongTrinhDaoTaos)
                    .HasForeignKey(h => h.MaNganh);
            });

            // Tạo dữ liệu cho bảng Khoa
            modelBuilder.Entity<Khoa>().HasData(
                new Khoa { MaKhoa = "K1", Ten = "Khoa Kỹ thuật", MoTa = "Mô tả khoa Kỹ thuật" },
                new Khoa { MaKhoa = "K2", Ten = "Khoa Kinh tế", MoTa = "Mô tả khoa Kinh tế" }
            // Thêm dữ liệu cho các khoa khác
            );

            // Tạo dữ liệu cho bảng Nganh
            modelBuilder.Entity<Nganh>().HasData(
                new Nganh { MaNganh = "N1", Ten = "Ngành Công nghệ thông tin", MoTa = "Mô tả ngành Công nghệ thông tin", MaKhoa = "K1" },
                new Nganh { MaNganh = "N2", Ten = "Ngành Kế toán", MoTa = "Mô tả ngành Kế toán", MaKhoa = "K2" }
            // Thêm dữ liệu cho các ngành khác
            );

            // Tạo dữ liệu cho bảng KhoaHoc
            modelBuilder.Entity<KhoaHoc>().HasData(
                new KhoaHoc { MaKhoaHoc = "KH1", Ten = "Khóa học Kỹ thuật phần mềm", MoTa = "Mô tả khóa học Kỹ thuật phần mềm", NgayBatDau = DateTime.Now, NgayKetThuc = DateTime.Now.AddDays(30) },
                new KhoaHoc { MaKhoaHoc = "KH2", Ten = "Khóa học Quản trị kinh doanh", MoTa = "Mô tả khóa học Quản trị kinh doanh", NgayBatDau = DateTime.Now, NgayKetThuc = DateTime.Now.AddDays(30) }
            // Thêm dữ liệu cho các khóa học khác
            );

            // Tạo dữ liệu cho bảng HocPhan
            modelBuilder.Entity<HocPhan>().HasData(
                new HocPhan { MaHocPhan = "HP1", Ten = "Lập trình C++", MoTa = "Mô tả học phần Lập trình C++", SoTinChi = 3, MaKhoa = "K1" },
                new HocPhan { MaHocPhan = "HP2", Ten = "Kế toán tài chính", MoTa = "Mô tả học phần Kế toán tài chính", SoTinChi = 3, MaKhoa = "K2" }
                );

            modelBuilder.Entity<KhoiKienThuc>().HasData(
                new KhoiKienThuc { MaKKT = "KKT1", Ten = "Khối kiến thức 1", MoTa = "Mô tả khối kiến thức 1" },
                new KhoiKienThuc { MaKKT = "KKT2", Ten = "Khối kiến thức 2", MoTa = "Mô tả khối kiến thức 2" }
            // Thêm dữ liệu cho các khối kiến thức khác
            );

            

            modelBuilder.Entity<ChuongTrinhDaoTao>().HasData(
                new ChuongTrinhDaoTao { MaCTDT = "CTDT1", Ten = "CTDT1", MaKhoa = "K1", MaKhoaHoc = "KH1", MaNganh = "N1", SoNamDaoTao = 2 },
                new ChuongTrinhDaoTao { MaCTDT = "CTDT2", Ten = "CTDT2", MaKhoa = "K1", MaKhoaHoc = "KH1", MaNganh = "N1", SoNamDaoTao = 2 }
            // Thêm dữ liệu cho các chi tiết CTĐT khác
            );
            modelBuilder.Entity<CTDT_KKT>().HasData(
                new CTDT_KKT { MaCTDT_KKT = "CTDT_KKT1", MaCTDT = "CTDT1", MaKKT = "KKT1" },
                new CTDT_KKT { MaCTDT_KKT = "CTDT_KKT2", MaCTDT = "CTDT1", MaKKT = "KKT2" }
            // Thêm dữ liệu cho các mối quan hệ giữa danh mục CTĐT và khối kiến thức khác
            );
            modelBuilder.Entity<GanHocPhan>().HasData(
                new GanHocPhan { MaCTDT_KKT = "CTDT_KKT1", MaHocPhan = "HP1" },
                new GanHocPhan { MaCTDT_KKT = "CTDT_KKT2", MaHocPhan = "HP2" }
            // Thêm dữ liệu cho các mối quan hệ giữa danh mục CTĐT và khối kiến thức khác
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}
