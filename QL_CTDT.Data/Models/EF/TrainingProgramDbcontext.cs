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
        public DbSet<DanhMucCTDT> DanhMucCTDTs { get; set; }
        public DbSet<DanhMucCTDT_KKT> DanhMucCTDT_KKTs { get; set; }
        public DbSet<ChiTietCTDT> ChiTietCTDTs { get; set; }
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

            modelBuilder.Entity<DanhMucCTDT>(entity =>
            {
                entity.HasKey(d => d.MaDanhMucCTDT);

                entity.HasOne(d => d.Khoa)
                    .WithMany(n => n.DanhMucCTDTs)
                    .HasForeignKey(d => d.MaKhoa).OnDelete(DeleteBehavior.NoAction); ;

                entity.HasOne(d => d.KhoaHoc)
                    .WithMany(kh => kh.DanhMucCTDTs)
                    .HasForeignKey(d => d.MaKhoaHoc).OnDelete(DeleteBehavior.NoAction);
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
            modelBuilder.Entity<DanhMucCTDT_KKT>(entity =>
            {
                entity.HasKey(h => h.MaDanhMucCTDT_KKT);
                entity.Property(h => h.MaKKT).IsRequired();
                entity.Property(h => h.MaDanhMucCTDT).IsRequired();

                entity.HasOne(d => d.DanhMucCTDT)
                    .WithMany(kh => kh.DanhMucCTDT_KKTs)
                    .HasForeignKey(d => d.MaDanhMucCTDT).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(d => d.KhoiKienThuc)
                    .WithMany(kh => kh.DanhMucCTDT_KKTs)
                    .HasForeignKey(d => d.MaKKT).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ChiTietCTDT>(entity =>
            {
                entity.HasKey(h => h.MaChiTietCTDT);
                entity.Property(h => h.MaHocPhan).IsRequired();
                entity.Property(h => h.MaDanhMucCTDT_KKT).IsRequired();
                entity.HasOne(h => h.HocPhan)
                    .WithMany(kh => kh.ChiTietCTDTs)
                    .HasForeignKey(h => h.MaHocPhan).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(h => h.DanhMucCTDT_KKT)
                    .WithMany(kh => kh.ChiTietCTDTs)
                    .HasForeignKey(h => h.MaDanhMucCTDT_KKT);

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
            modelBuilder.Entity<DanhMucCTDT>().HasData(
                new DanhMucCTDT { MaDanhMucCTDT = "CTDT1", MaKhoa = "K1", MaKhoaHoc = "KH1" },
                new DanhMucCTDT { MaDanhMucCTDT = "CTDT2", MaKhoa = "K2", MaKhoaHoc = "KH2" }
            // Thêm dữ liệu cho các danh mục CTĐT khác  
                );

            modelBuilder.Entity<KhoiKienThuc>().HasData(
                new KhoiKienThuc { MaKKT = "KKT1", Ten = "Khối kiến thức 1", MoTa = "Mô tả khối kiến thức 1" },
                new KhoiKienThuc { MaKKT = "KKT2", Ten = "Khối kiến thức 2", MoTa = "Mô tả khối kiến thức 2" }
            // Thêm dữ liệu cho các khối kiến thức khác
            );

            modelBuilder.Entity<DanhMucCTDT_KKT>().HasData(
                new DanhMucCTDT_KKT { MaDanhMucCTDT_KKT = "CTDT_KKT_1", MaDanhMucCTDT = "CTDT1", MaKKT = "KKT1" },
                new DanhMucCTDT_KKT { MaDanhMucCTDT_KKT = "CTDT_KKT_2", MaDanhMucCTDT = "CTDT1", MaKKT = "KKT2" }
            // Thêm dữ liệu cho các mối quan hệ giữa danh mục CTĐT và khối kiến thức khác
            );

            modelBuilder.Entity<ChiTietCTDT>().HasData(
                new ChiTietCTDT { MaChiTietCTDT = "1", MaHocPhan = "HP1", MaDanhMucCTDT_KKT = "CTDT_KKT_1" },
                new ChiTietCTDT { MaChiTietCTDT = "2", MaHocPhan = "HP2", MaDanhMucCTDT_KKT = "CTDT_KKT_2" }
            // Thêm dữ liệu cho các chi tiết CTĐT khác
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}
