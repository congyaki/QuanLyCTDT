using QL_CTDT.Data.Models.ViewModels;

namespace QL_CTDT.Data.Models.Entities
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public List<Nganh> Nganhs { get; set; }
        public List<HocPhan> HocPhans { get; set; }
        public  List<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }

    }
}
