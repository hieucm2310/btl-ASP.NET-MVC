using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLVinamilk.Models;
using PagedList;

namespace BTLVinamilk.Areas.Admin.Controllers
{
    public class SUAsController : Controller
    {
        private VinamilkDB db = new VinamilkDB();

        // GET: SUAs
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "gia" ? "gia_desc" : "gia";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var sUAs = db.SUAs.Include(s => s.DMSUA);
            if (!String.IsNullOrEmpty(searchString))
            {
                sUAs = sUAs.Where(s => s.TieuDe.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ten_desc":
                    sUAs = sUAs.OrderByDescending(s => s.TieuDe);
                    break;
                case "gia":
                    sUAs = sUAs.OrderBy(s => s.GiaBan);
                    break;
                case "gia_desc":
                    sUAs = sUAs.OrderByDescending(s => s.GiaBan);
                    break;
                default:
                    sUAs = sUAs.OrderBy(s => s.TieuDe);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sUAs.ToPagedList(pageNumber,pageSize));
        }

        // GET: SUAs/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
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

        // GET: SUAs/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            ViewBag.IDDM = new SelectList(db.DMSUAs, "IDDM", "TenDM");
            return View();
        }

        // POST: SUAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TieuDe,AnhBia,SoLuong,GiaBan,Mota,IDDM")] SUA sUA)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            try
            {
                if (ModelState.IsValid)
                {
                    sUA.AnhBia = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(UploadPath);
                        sUA.AnhBia = FileName;
                    }
                    db.SUAs.Add(sUA);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                ViewBag.IDDM = new SelectList(db.DMSUAs, "IDDM", "TenDM", sUA.IDDM);
                return View(sUA);
            }
        }

        // GET: SUAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
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

        // POST: SUAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TieuDe,AnhBia,SoLuong,GiaBan,Mota,IDDM")] SUA sUA)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            try
            {
                if (ModelState.IsValid)
                {
                    sUA.AnhBia = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(UploadPath);
                        sUA.AnhBia = FileName;
                    }
                    db.Entry(sUA).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi sửa dữ liệu! " + ex.Message;
                ViewBag.IDDM = new SelectList(db.DMSUAs, "IDDM", "TenDM", sUA.IDDM);
                return View(sUA);
            }
        }

        // GET: SUAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
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

        // POST: SUAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            SUA sUA = db.SUAs.Find(id);
            try
            {
                db.SUAs.Remove(sUA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được bản ghi này!" + ex.Message;
                return View("Delete", sUA);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Display(int? page)
        {
            var sua = db.SUAs.Select(s => s);
            sua = sua.OrderBy(s => s.ID);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sua.ToPagedList(pageNumber, pageSize));
        }
    }
}