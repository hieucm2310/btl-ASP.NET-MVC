using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLVinamilk.Models;

namespace BTLVinamilk.Areas.Admin.Controllers
{
    public class RController : Controller
    {
        VinamilkDB db = new VinamilkDB();
        // GET: Admin/R
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = ""});
            }
            return View();
        }
    }
}