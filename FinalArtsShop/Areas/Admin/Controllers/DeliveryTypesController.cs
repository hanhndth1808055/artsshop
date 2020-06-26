using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeliveryTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryTypes
        public ActionResult Index()
        {
            return View(db.DeliveryTypes.ToList());
        }

        // GET: DeliveryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            if (deliveryType == null)
            {
                return HttpNotFound();
            }
            return View(deliveryType);
        }

        // GET: DeliveryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abbreviation,Factor,Active,CreatedAt,UpdatedAt")] DeliveryType deliveryType)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryTypes.Add(deliveryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryType);
        }

        // GET: DeliveryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            if (deliveryType == null)
            {
                return HttpNotFound();
            }
            return View(deliveryType);
        }

        // POST: DeliveryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abbreviation,Factor,Active,CreatedAt,UpdatedAt")] DeliveryType deliveryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryType);
        }

        // GET: DeliveryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            if (deliveryType == null)
            {
                return HttpNotFound();
            }
            return View(deliveryType);
        }

        // POST: DeliveryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            db.DeliveryTypes.Remove(deliveryType);
            db.SaveChanges();
            return RedirectToAction("Index");
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
