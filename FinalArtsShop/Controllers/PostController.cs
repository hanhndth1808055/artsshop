using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Home", "Home");
            }
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return RedirectToAction("Home", "Home");
            }

            var postPrev = db.Posts.Where(p => p.Id < id).FirstOrDefault();
            var postNext = db.Posts.Where(p => p.Id > id).FirstOrDefault();
            int idPrev;
            int idNext;

            if (postPrev != null)
            {
                idPrev = postPrev.Id;
            }
            else
            {
                idPrev = id.Value;
            }

            if (postNext != null)
            {
                idNext = postNext.Id;
            }
            else
            {
                idNext = id.Value;
            }

            post.View = post.View + 1;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();

            ViewPostClient viewPostClient = new ViewPostClient()
            {
                Post = post,
                IdPrev = idPrev,
                IdNext = idNext,
                FeatureProducts = db.Products.Where(p => p.isFeature == 1 && p.isActive == 1).Take(5).ToList(),
            };
            return View(viewPostClient);
        }

        public int AjaxPostLike(int? id)
        {
            var countLike = 0;
            if (id == null)
            {
                return countLike;
            }

            var post = db.Posts.Find(id);
            if (post == null)
            {
                return countLike;
            }
            countLike = post.Like + 1;

            post.Like = countLike;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();

            return countLike;
        }

    }
}