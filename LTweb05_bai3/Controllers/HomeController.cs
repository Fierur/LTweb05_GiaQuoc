using LTweb05_bai3.Models;
using LTweb05_bai3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTweb05_bai3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        KetNoiDuLieu LoaiSP = new KetNoiDuLieu();
        public ActionResult DanhSachLoai()
        {
            

            List<Loai> ListLoai = LoaiSP.dsLoaiSP;
            return View(ListLoai);
        }
        public ActionResult DanhSachSP()
        {
            List<SanPham> ListSP = LoaiSP.dsSP;
            return View(ListSP);
        }

        [HttpGet]
        public ActionResult ChiTietLoai(int? id)
        {
            SanPhamTheoLoai loai = new SanPhamTheoLoai();

            // Neu id null hoac 0, lay loai dau tien trong danh sach
            if (id == null || id == 0)
            {
                if (LoaiSP.dsLoaiSP.Any())
                {
                    id = LoaiSP.dsLoaiSP.First().MaLoai;
                }
                else
                {
                    // Khong co loai nao, tra ve view trong
                    return View(loai);
                }
            }

            Loai lsp = LoaiSP.ChiTietLoai(id.Value);
            List<SanPham> sptheoloai = LoaiSP.LayDSSanPhamTheoLoai(id.Value);
            loai.Loai = lsp;
            loai.SanPham = sptheoloai;
            return View(loai);
        }
        [HttpGet]
        public ActionResult TimKiemTheoTen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimKiemTheoTen(string tensp)
        {
            List<SanPham> ListSP = LoaiSP.TimKiemSanPham(tensp);
            ViewBag.TuKhoa = tensp;
            ViewBag.SoLuong = ListSP.Count;
            return View(ListSP);
        }

        [HttpGet]
        public ActionResult TimKiemTheoLoai()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimKiemTheoLoai(int maloai)
        {
            List<SanPham> ListSP = LoaiSP.LayDSSanPhamTheoLoai(maloai);
            ViewBag.LoaiDaChon = maloai;
            return View(ListSP);
        }
    }
}