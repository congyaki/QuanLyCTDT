using QL_CTDT.Data.Models.ViewModels;

namespace QL_CTDT.Data.Models.Entities
{
    public class Nganh
    {
        public string MaNganh { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string MaKhoa { get; set; }
        public Khoa Khoa { get; set; }
        public List<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }

    }
}
