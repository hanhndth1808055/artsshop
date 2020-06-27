using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryID,Name,Description,UnitPrice,PromotionPrice,Thumbnail,Image,Unit,isNew,isActive,CreatedAt,UpdatedAt,isFeature,SellIndex")] Product product, String[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                var CurrentCategory = db.Categories.Find(product.CategoryID);
                if(CurrentCategory != null)
                {
                    product.Category = CurrentCategory;
                }

                var lastestProduct = db.Counters.Where(p => p.Active == ActiveEnum.Active).FirstOrDefault();

                if (lastestProduct == null)
                {
                    var id = CurrentCategory.Abbreviation + "00001";
                    product.Id = id;
                    var counter = new Counter()
                    {
                        CountProduct = 1,
                        Active = ActiveEnum.Active
                    };
                    db.Counters.Add(counter);
                    db.SaveChanges();
                }
                else
                {
                    var index = (lastestProduct.CountProduct + 1).ToString();
                    var id = index.PadLeft(5, '0');

                    product.Id = CurrentCategory.Abbreviation + id;
                    lastestProduct.CountProduct++;
                    if (ModelState.IsValid)
                    {
                        db.Entry(lastestProduct).State = EntityState.Modified;
                        db.Counters.AddOrUpdate(lastestProduct);
                    }

                    db.SaveChanges();
                }
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    product.Thumbnail = string.Join(",", thumbnails);
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryID,Name,Description,UnitPrice,PromotionPrice,Thumbnail,Image,Unit,isNew,isActive,CreatedAt,UpdatedAt,isFeature,SellIndex")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
