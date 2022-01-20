using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLVinamilk.Models;

namespace BTLVinamilk.Controllers
{
    public class SUAsController : Controller
    {
        private VinamilkDB db = new VinamilkDB();

        // GET: SUAs
        public ActionResult Index(string id)
        {
            List<SUA> danhsach = new List<SUA>();
            if (id != null)
            {
                danhsach = db.SUAs.Where(s => s.IDDM == id)
                    .Select(s => s).ToList();
            }
            else
            {
                danhsach = db.SUAs.Include(s => s.DMSUA).ToList();
            }
            if (danhsach == null)
            {
                Response.Write("Không có sữa thuộc danh mục sữa này");
            }
            return View(danhsach);
        }

        // GET: SUAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUA sUA = db.SUAs.Find(id);
            if (sUA == null)
            {
                return HttpNotFound();
            }
            return View(sUA);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUA sUA = db.SUAs.Find(id);
            if (sUA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDM = new SelectList(db.DMSUAs, "IDDM", "TenDM", sUA.IDDM);
            return View(sUA);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
