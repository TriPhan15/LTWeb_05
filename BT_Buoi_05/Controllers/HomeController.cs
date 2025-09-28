using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BT_Buoi_05.Models;
using BT_Buoi_05.ViewModel;
namespace BT_Buoi_05.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiNhanvien()
        {
            List<Employee> ds = csdl.dsNV;
            return View(ds);
        }
        public ActionResult HienThiPhongBan()
        {
            List<PhongBan> ds = csdl.DSPB;
            return View(ds);
        }
        [HttpGet]
        public ActionResult Detail_PhongBan(int id)
        {
            PhongBanModel pb = new PhongBanModel();
            PhongBan ds = csdl.ChiTietPhongBan(id);
            List<Employee> dsnv = csdl.DanhSachNhanVienTheoMaPhong(id);
            pb.PhongBan = ds;
            pb.NhanVien = dsnv;
            return View(pb);
        }
        [HttpGet]
        public ActionResult AddNew_PhongBan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew_PhongBan(string id, string name)
        {
            PhongBan pb = new PhongBan();
            pb.MaPhong = int.Parse(id);
            pb.TenPhong = name;
            bool result = csdl.ThemPhongBan(pb);
            ViewBag.message = result == true ? "success" : "fail";
            return View();
        }
        [HttpGet]
        public ActionResult Edit_PhongBan(int id)
        {
            PhongBan ds = csdl.ChiTietPhongBan(id);
            return View(ds);
        }
        [HttpPost]
        public ActionResult Edit_PhongBan(string id,string name)
        {
            PhongBan pb = new PhongBan();
            pb.MaPhong = int.Parse(id);
            pb.TenPhong = name;
            bool result = csdl.CapNhatPhongBan(pb);
            ViewBag.message = result == true ? "success" : "fail";
            return View(pb);
        }
        public ActionResult Delete_PhongBan(int id)
        {
            bool result = csdl.XoaPhongBan(id);
            return RedirectToAction("HienThiPhongBan", "Home");
        }
    }
}