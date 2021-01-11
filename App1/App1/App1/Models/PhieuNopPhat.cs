using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class PhieuNopPhat
    {
        public int ma_phieu { get; set; }
        public byte flag_ship { get; set; }
        public int tien_phat { get; set; }
        public int tien_ship { get; set; }
        public int tong_tien_nop { get; set; }
        public string phuong_thuc_dong_phat { get; set; }
        public string dia_chi_ship { get; set; }
        public DateTime ngay_nop_phat { get; set; }
        public byte flag_da_nhan_xe { get; set; }
        public int ma_vi_pham { get; set; }
    }
}
