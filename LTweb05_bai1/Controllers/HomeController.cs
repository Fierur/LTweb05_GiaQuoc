using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTweb05_bai1.Models;
using LTweb05_bai1.ViewModel;
using LTweb05_Bai1.Models;

namespace LTweb05_Bai1.Controllers
{
    public class HomeController : Controller
    {

        DuLieu csdl = new DuLieu();
        public ActionResult ShowEmp()
        {
            List<Bai1> ds = csdl.dsNV;
            return View(ds);
        }

        public ActionResult ShowDept()
        {
            List<Department> dspb = csdl.dsPB;
            return View(dspb);
        }

        [HttpGet]
        public ActionResult DetailPB(int id)
        {
            DViewModel deparment = new DViewModel();
            Department ds = csdl.ChiTietPB(id);
            List<Bai1> dsnv = csdl.DSNVTheoMaPhong(id);
            deparment.Department = ds;
            deparment.Employee = dsnv;
            return View(deparment);
        }
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
    }
}