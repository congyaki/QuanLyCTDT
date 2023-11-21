using QL_CTDT.Data.Models.Entities;
using QL_CTDT.Data.Models.ViewModels;

namespace QL_CTDT.Data.Models.Entities
{
    public class KhoiKienThuc
    {
        public string MaKKT { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public List<CTDT_KKT> CTDT_KKTs { get; set; }
    }
}
