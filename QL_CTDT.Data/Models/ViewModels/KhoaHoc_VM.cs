using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.ViewModels
{
    public class KhoaHoc_VM
    {
        public string? MaKhoaHoc { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
