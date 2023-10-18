namespace QuanLyCTDT.Models
{
    public class Nganh
    {
        public int NganhID { get; set; }
        public string TenNganh { get; set; }
        public string MoTa { get; set; }
        public int KhoaID { get; set; }
        public Khoa Khoa { get; set; }
        public List<KhoaHoc> KhoaHocs { get; set;}
    }
}
