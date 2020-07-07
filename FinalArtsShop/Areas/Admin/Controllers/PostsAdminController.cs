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
    [Authorize]
    public class PostsAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PostsAdmin
        public ActionResult Index(DateTime? start, DateTime? end)
        {
            var post = db.Posts.AsQueryable();
            post = post.OrderByDescending(p => p.CreatedAt);

            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                post = post.Where(p => p.CreatedAt >= startDate);
            }

            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                post = post.Where(p => p.CreatedAt <= endDate);
            }

            return View(post.ToList());
        }

        // GET: Admin/PostsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/PostsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PostsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,Description,Thumbnail,View,Like,CreatedAt,UpdatedAt")] Post post, String[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    post.Thumbnail = string.Join(",", thumbnails);
                }
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Admin/PostsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/PostsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Description,Thumbnail,View,Like,CreatedAt,UpdatedAt")] Post post, String[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    post.Thumbnail = string.Join(",", thumbnails);
                }
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Admin/PostsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/PostsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
