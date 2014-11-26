using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Models;

namespace Vendor.Web.Controllers
{
    public class VendorUsersController : Controller
    {
        private CarHealthEntities db = new CarHealthEntities();

        [AllowAnonymous]
        // GET: VendorUsers
        public ActionResult Index()
        {
            return View(db.VendorUsers.ToList());
        }

        [AllowAnonymous]
        // GET: VendorUsers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = db.VendorUsers.Find(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        [AllowAnonymous]
        // GET: VendorUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        // POST: VendorUsers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VendorId,RoleId,Name,NickName,Password,LatestLoginDt,LatestLoginIp")] VendorUser vendorUser)
        {
            if (ModelState.IsValid)
            {
                db.VendorUsers.Add(vendorUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorUser);
        }

        [AllowAnonymous]
        // GET: VendorUsers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = db.VendorUsers.Find(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        [AllowAnonymous]
        // POST: VendorUsers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VendorId,RoleId,Name,NickName,Password,LatestLoginDt,LatestLoginIp")] VendorUser vendorUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorUser);
        }

        [AllowAnonymous]
        // GET: VendorUsers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = db.VendorUsers.Find(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        [AllowAnonymous]
        // POST: VendorUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VendorUser vendorUser = db.VendorUsers.Find(id);
            db.VendorUsers.Remove(vendorUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
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
