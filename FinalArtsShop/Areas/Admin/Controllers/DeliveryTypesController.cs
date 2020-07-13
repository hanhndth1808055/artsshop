using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        public ActionResult Index(DateTime? start, DateTime? end)
        {
            var deliveryTypes = db.DeliveryTypes.AsQueryable();

            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                deliveryTypes = deliveryTypes.Where(p => p.CreatedAt >= startDate);
            }

            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                deliveryTypes = deliveryTypes.Where(p => p.CreatedAt <= endDate);
            }

            return View(deliveryTypes.ToList());
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

        [HttpPost]
        public JsonResult DeliveryTypesDeleteWithAjax(string[] idArray)
        {
            foreach (string id in idArray)
            {
                DeliveryType deliveryType = db.DeliveryTypes.Find(id);
                if (deliveryType != null && deliveryType.Active != 0)
                {
                    deliveryType.Active = 0;
                    db.DeliveryTypes.AddOrUpdate(deliveryType);
                }
            }
            db.SaveChanges();
            var data = "Success";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
