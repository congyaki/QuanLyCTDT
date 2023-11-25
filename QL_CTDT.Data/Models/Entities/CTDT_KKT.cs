using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.Entities
{
    public class CTDT_KKT
    {
        public string MaCTDT_KKT { get; set; }
        public string TenCTDT_KKT { get; set; }
        public string MaCTDT { get; set; }
        public string MaKKT { get; set; }
        public KhoiKienThuc KhoiKienThuc { get; set; }
        public List<GanHocPhan> GanHocPhans { get; set; }
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
    }
}
