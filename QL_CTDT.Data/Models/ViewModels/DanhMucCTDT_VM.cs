using QL_CTDT.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.ViewModels
{
    public class DanhMucCTDT_VM
    {
        public string TenKhoaHoc { get; set; }
        public string? MaKhoaHoc { get; set; }
        public string TenNganh { get; set; }
        public string? MaNganh { get; set; }
        public string TenCTDT { get; set; }
        public string? MaCTDT { get; set; }
        public string TenKhoa { get; set; }
        public string? MaKhoa { get; set; }
    }
}
