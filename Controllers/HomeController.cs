using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BTLVinamilk.Models;

namespace BTLVinamilk.Controllers
{
    public class HomeController : Controller
    {
        private VinamilkDB db = new VinamilkDB();
        private List<SUA> Laysuamoi(int count)
        {
            return db.SUAs.OrderByDescending(a => a.ID).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var suamoi = Laysuamoi(5);
            return View(suamoi);
        }

        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var ten = collection["Ten"];
            var matkhau = collection["MatKhau"];
            ViewBag.ThongBao = ten + matkhau;
            if (String.IsNullOrEmpty(ten))
            {
                { ViewData["Loi1"] = "Phải nhập tên đăng nhập"; }
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                { ViewData["Loi2"] = "Phải nhập mật khẩu"; }
            }
            else
            {
                TAIKHOAN tk = db.TAIKHOANs
                    .Where(n => n.Ten.Trim() == ten)
                    .FirstOrDefault();
                if (tk == null)
                {
                    ViewBag.Thongbao = "Tên tài khoản không tồn tại";
                }
                else
                {
                    if (tk.QuenTC.Trim().Equals("user"))
                    {
                        if (tk.MatKhau.Trim().Equals(matkhau))
                        {
                            Session.Add("user", tk.Ten);
                            ViewBag.Thongbao = $"Đăng nhập tài khoản người dùng {tk.Ten} thành công,";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        }
                    }
                    if (tk.QuenTC.Trim().Equals("admin"))
                    {
                        if (tk.MatKhau.Trim().Equals(matkhau))
                        {
                            Session["admin"] = tk.Ten;
                            ViewBag.Thongbao = tk.Ten + tk.MatKhau;
                            return RedirectToAction("Index", "R", new { area = "Admin" });
                        }
                        else
                        {
                            ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        }
                    }
                }
            }
            return View();
        }
    }
}