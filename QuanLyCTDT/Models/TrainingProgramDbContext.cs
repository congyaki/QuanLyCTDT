using Microsoft.EntityFrameworkCore;

namespace QuanLyCTDT.Models
{
    public class TrainingProgramDbContext : DbContext
    {
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Cấu hình chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-AVPLSS5\\SQLEXPRESS;Initial Catalog=TrainingProgramManagementDB;User ID=sa;Password=Satrymra2003!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public TrainingProgramDbContext(DbContextOptions<TrainingProgramDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(k => k.KhoaID);
                entity.Property(k => k.TenKhoa).IsRequired().HasMaxLength(100);
                entity.Property(k => k.MoTa).HasMaxLength(200);
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(n => n.NganhID);
                entity.Property(n => n.TenNganh).IsRequired().HasMaxLength(100);
                entity.Property(n => n.MoTa).HasMaxLength(200);

                entity.HasOne(n => n.Khoa)
                    .WithMany(k => k.Nganhs)
                    .HasForeignKey(n => n.KhoaID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.HasKey(kh => kh.KhoaHocID);
                entity.Property(kh => kh.TenKhoaHoc).IsRequired().HasMaxLength(100);
                entity.Property(kh => kh.MoTa).HasMaxLength(200);
                entity.Property(kh => kh.NgayBatDau).IsRequired();
                entity.Property(kh => kh.NgayKetThuc).IsRequired();

                entity.HasOne(kh => kh.Nganh)
                    .WithMany(n => n.KhoaHocs)
                    .HasForeignKey(kh => kh.NganhID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Khoa>().HasData(
                new Khoa { KhoaID = 1, TenKhoa = "Khoa Công nghệ thông tin", MoTa = "Khoa Công nghệ thông tin" },
                new Khoa { KhoaID = 2, TenKhoa = "Khoa Kinh tế", MoTa = "Khoa Kinh tế" },
                new Khoa { KhoaID = 3, TenKhoa = "Khoa Quản trị kinh doanh", MoTa = "Khoa Quản trị kinh doanh" }
            );

            modelBuilder.Entity<Nganh>().HasData(
                new Nganh { NganhID = 1, TenNganh = "Công nghệ thông tin", MoTa = "Ngành Công nghệ thông tin", KhoaID = 1 },
                new Nganh { NganhID = 2, TenNganh = "Hệ thống thông tin", MoTa = "Ngành Hệ thống thông tin", KhoaID = 1 },
                new Nganh { NganhID = 3, TenNganh = "Kế toán", MoTa = "Ngành Kế toán", KhoaID = 2 },
                new Nganh { NganhID = 4, TenNganh = "Marketing", MoTa = "Ngành Marketing", KhoaID = 3 }
            );

            modelBuilder.Entity<KhoaHoc>().HasData(
                new KhoaHoc { KhoaHocID = 1, TenKhoaHoc = "Lập trình C#", MoTa = "Khóa học lập trình C#", NgayBatDau = new DateTime(2023, 1, 1), NgayKetThuc = new DateTime(2023, 1, 30), NganhID = 1 },
                new KhoaHoc { KhoaHocID = 2, TenKhoaHoc = "Quản lý dự án", MoTa = "Khóa học quản lý dự án", NgayBatDau = new DateTime(2023, 2, 1), NgayKetThuc = new DateTime(2023, 2, 28), NganhID = 2 },
                new KhoaHoc { KhoaHocID = 3, TenKhoaHoc = "Kế toán tài chính", MoTa = "Khóa học kế toán tài chính", NgayBatDau = new DateTime(2023, 3, 1), NgayKetThuc = new DateTime(2023, 3, 31), NganhID = 3 },
                new KhoaHoc { KhoaHocID = 4, TenKhoaHoc = "Digital Marketing", MoTa = "Khóa học Digital Marketing", NgayBatDau = new DateTime(2023, 4, 1), NgayKetThuc = new DateTime(2023, 4, 30), NganhID = 4 }
            );
        }


    }
}
