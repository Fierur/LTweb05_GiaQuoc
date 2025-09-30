using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTweb05_bai3.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string DuongDan { get; set; }
        public double Gia { get; set; }
        public string MoTa { get; set; }
        public int MaLoai { get; set; }
    }
}