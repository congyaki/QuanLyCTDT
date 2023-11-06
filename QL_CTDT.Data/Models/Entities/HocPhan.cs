﻿using QL_CTDT.Data.Models.Entities;

namespace QL_CTDT.Data.Models.Entities
{
    public class HocPhan
    {
        public string MaHocPhan { get; set; }

        public string Ten { get; set; }

        public string MoTa { get; set; }

        public int SoTinChi { get; set; }
        public string MaKhoa { get; set; }
        public Khoa? Khoa { get; set; }

        public List<ChiTietCTDT>? ChiTietCTDTs { get; set; }
    }
}
