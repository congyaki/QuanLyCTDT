using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.Entities
{
    public class ChiTietCTDT
    {
        public string MaChiTietCTDT { get; set; }
        public string MaHocPhan { get; set; }
        public string MaDanhMucCTDT_KKT { get; set; }
        public HocPhan? HocPhan { get; set; }
        public DanhMucCTDT_KKT? DanhMucCTDT_KKT { get; set; }
    }
}
