using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Bai_03.Models;
using Bai_03.ViewModel;
namespace Bai_03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        DuLieu csdl = new DuLieu();
        public ActionResult ShowLoai()
        {
            List<Loai> loai = csdl.DSLoai;
            return View(loai);
        }
        public ActionResult ShowSanPham()
        {
            List<SanPham> sp = csdl.DSSanPham;
            return View(sp);
        }

        public ActionResult ShowSp_Loai(int? ma)
        {
            SanPham_Loai_Model em = new SanPham_Loai_Model();
            if (!ma.HasValue)
            {
                // Handle the case where ma is null (e.g., show all products or return an error view)
                em.loai = csdl.DSLoai; // Load all categories
                em.sanPham = csdl.DSSanPham; // Load all products
            }
            else
            {
                em.loai = csdl.DanhSachLoai(ma.Value);
                em.sanPham = csdl.DanhSachSanPham(ma.Value);
            }
            return View(em);
        }
        [HttpGet]
        public ActionResult TimKiemSP( )
        {
            List<SanPham> sp = csdl.DSSanPham;
            return View(sp);
        }
        [HttpPost]
        public ActionResult TimKiemSP(string ten)
        {
            List<SanPham> sp;
            if (string.IsNullOrEmpty(ten))
            {
                sp = csdl.DSSanPham; // Nếu không nhập ten, hiển thị tất cả sản phẩm
            }
            else
            {
                sp = csdl.TimKiemSanPham(ten); // Tìm kiếm theo ten
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult TimKiemTheoLoai()
        {
            var em = new SanPham_Loai_Model
            {
                sanPham = csdl.DSSanPham,
                loai = csdl.DSLoai,
                SelectedMaLoai = 0
            };
            return View(em);
        }

        [HttpPost]
        public ActionResult TimKiemTheoLoai(int ma)
        {
            var model = new SanPham_Loai_Model
            {
                sanPham = (ma == 0) ? csdl.DSSanPham : csdl.TimKiemTheoLoai(ma),
                loai = csdl.DSLoai,
                SelectedMaLoai = ma
            };

            return View(model);
        }

    }
}