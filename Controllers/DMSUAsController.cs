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
    public class DMSUAsController : Controller
    {
        private VinamilkDB db = new VinamilkDB();

        // GET: DMSUAs
        public ActionResult Index()
        {
            var check = db.DMSUAs.FirstOrDefault();
            if (check == null)
            {
                Response.Write("Không có danh mục sữa nào");
            }
            return View(db.DMSUAs.ToList());
        }

        // GET: DMSUAs/Details/5
        public ActionResult Details(string id)
        {
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
            return View();
        }

        // POST: DMSUAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDM,TenDM,AnhDM")] DMSUA dMSUA)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
            try
            {
                if (ModelState.IsValid)
                {
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
