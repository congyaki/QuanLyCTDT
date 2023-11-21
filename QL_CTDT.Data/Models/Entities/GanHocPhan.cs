using QL_CTDT.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.Entities
{
    public class GanHocPhan
    {
        public string MaCTDT_KKT { get; set; }
        public string MaHocPhan { get; set; }
        public HocPhan HocPhan { get; set; }
        public CTDT_KKT CTDT_KKT { get; set; }
    }
}
