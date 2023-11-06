using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.Entities
{
    public class DanhMucCTDT_KKT
    {
        public string MaDanhMucCTDT_KKT { get; set; }
        public string MaDanhMucCTDT { get; set; }
        public string MaKKT { get; set; }
        public DanhMucCTDT? DanhMucCTDT { get; set; }
        public KhoiKienThuc? KhoiKienThuc { get; set; }
        public List<ChiTietCTDT>? ChiTietCTDTs { get; set; }
    }
}
