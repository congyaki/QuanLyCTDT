using QL_CTDT.Data.Models.Entities;

namespace QL_CTDT.Data.Models.Entities
{
    public class DanhMucCTDT
    {
        public string MaDanhMucCTDT { get; set; }
        public string MaKhoa { get; set; }
        public string MaKhoaHoc { get; set; }

        public Khoa Khoa { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public List<DanhMucCTDT_KKT>? DanhMucCTDT_KKTs { get; set; }

    }
}
