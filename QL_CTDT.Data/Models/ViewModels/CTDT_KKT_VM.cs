﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CTDT.Data.Models.ViewModels
{
    public class CTDT_KKT_VM
    {
        public string TenKKT { get; set; }
        public int? TongSoHocPhan { get; set; }
        public List<HocPhan_VM> HocPhans { get; set;}
    }
}