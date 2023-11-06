namespace QL_CTDT.Data.Models.Entities
{
    public class KhoaHoc
    {
        public string MaKhoaHoc { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public List<DanhMucCTDT>? DanhMucCTDTs { get; set; }

    }
}
