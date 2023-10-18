namespace QuanLyCTDT.Models
{
    public class Khoa
    {
        public int KhoaID { get; set; }
        public string TenKhoa { get; set; }
        public string MoTa { get; set; }

        public List<Nganh> Nganhs { get; set; }
    }
}
