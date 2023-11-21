using QL_CTDT.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.Entities
{
    public class ChuongTrinhDaoTao
    {
        public string MaCTDT { get; set; }
        public string Ten { get; set; }
        public string MaKhoa { get; set; }
        public string MaKhoaHoc { get; set; }
        public string MaNganh { get; set; }
        public float SoNamDaoTao { get; set; }
        public Khoa Khoa { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public Nganh Nganh { get; set; }
        public List<CTDT_KKT> CTDT_KKTs { get; set; }
    }
}
