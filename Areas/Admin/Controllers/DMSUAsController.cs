
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLVinamilk.Models;

namespace BTLVinamilk.Areas.Admin.Controllers
{
    public class DMSUAsController : Controller
    {
        private VinamilkDB db = new VinamilkDB();

        // GET: DMSUAs
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            return View(db.DMSUAs.ToList());
        }

        // GET: DMSUAs/Details/5
        public ActionResult Details(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSUA dMSUA = db.DMSUAs.Find(id);
            if (dMSUA == null)
            {
                return HttpNotFound();
            }
            return View(dMSUA);
        }

        // GET: DMSUAs/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            return View();
        }

        // POST: DMSUAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDM,TenDM,AnhDM")] DMSUA dMSUA)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            try
            {
                if (ModelState.IsValid)
                {
                    dMSUA.AnhDM = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(UploadPath);
                        dMSUA.AnhDM = FileName;
                    }
                    db.DMSUAs.Add(dMSUA);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                return View(dMSUA);
            }
        }

        // GET: DMSUAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSUA dMSUA = db.DMSUAs.Find(id);
            if (dMSUA == null)
            {
                return HttpNotFound();
            }
            return View(dMSUA);
        }

        // POST: DMSUAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDM,TenDM,AnhDM")] DMSUA dMSUA)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            try
            {
                if (ModelState.IsValid)
                {
                    dMSUA.AnhDM = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(UploadPath);
                        dMSUA.AnhDM = FileName;
                    }
                    db.Entry(dMSUA).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi sửa dữ liệu! " + ex.Message;
                return View(dMSUA);
            }
        }

        // GET: DMSUAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSUA dMSUA = db.DMSUAs.Find(id);
            if (dMSUA == null)
            {
                return HttpNotFound();
            }
            return View(dMSUA);
        }

        // POST: DMSUAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            DMSUA dMSUA = db.DMSUAs.Find(id);
            try
            {
                db.DMSUAs.Remove(dMSUA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được bản ghi này! " + ex.Message;
                return View("Delete", dMSUA);
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
    }
}