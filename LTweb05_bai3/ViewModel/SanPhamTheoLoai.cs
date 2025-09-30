using LTweb05_bai3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTweb05_bai3.ViewModel
{
    public class SanPhamTheoLoai
    {
        public Loai Loai { get; set; }
        public List<SanPham> SanPham { get; set; }
    }
}