namespace QuanLyCTDT.Models
{
    public class KhoaHoc
    {
        public int KhoaHocID { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int NganhID { get; set; }
        public Nganh Nganh { get; set; }
    }
}
