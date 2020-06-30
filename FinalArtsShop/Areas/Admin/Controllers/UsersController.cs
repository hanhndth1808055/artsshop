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
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var usersWithRoles = (from applicationUser in db.Users
                                  from userRole in applicationUser.Roles
                                  join role in db.Roles on userRole.RoleId equals role.Id
                                  select new UserViewModel()
                                  {
                                      Id = applicationUser.Id,
                                      UserName = applicationUser.UserName,
                                      Email = applicationUser.Email,
                                      PhoneNumber = applicationUser.PhoneNumber,
                                      Role = role.Name,
                                      Status = applicationUser.LockoutEnabled,
                                  });
            var activeUser = usersWithRoles.Where(u => u.Status == false);
            return View(usersWithRoles);
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            var userViewModel = new UserViewModel()
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                PhoneNumber = applicationUser.PhoneNumber,
                Role = db.Roles.Find(applicationUser.Roles.FirstOrDefault().RoleId).Name,
                Status = applicationUser.LockoutEnabled
            };
            return View(userViewModel);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,CityId,DistrictId,Address,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", applicationUser.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", applicationUser.DistrictId);
            return View(applicationUser);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            var allRoles = db.Roles.ToList();
            var userViewModel = new UserViewModel()
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                PhoneNumber = applicationUser.PhoneNumber,
                Role = db.Roles.Find(applicationUser.Roles.FirstOrDefault().RoleId).Name,
                RolesList = allRoles.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
            };
            return View(userViewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,UserName,Role")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(userViewModel.Id);
                applicationUser.Email = userViewModel.Email;
                applicationUser.UserName = userViewModel.UserName;
                var oldRoleId = db.Roles.Find(applicationUser.Roles.FirstOrDefault().RoleId).Id;
                if (userViewModel.Role != oldRoleId)
                {
                    var newRoleId = db.Roles.SingleOrDefault(m => m.Id == userViewModel.Role).Id;
                    applicationUser.Roles.FirstOrDefault().RoleId = newRoleId;
                    userViewModel.Role = db.Roles.SingleOrDefault(m => m.Id == newRoleId).Name;
                }
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            var allRoles = db.Roles.ToList();
            var userViewModel = new UserViewModel()
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                PhoneNumber = applicationUser.PhoneNumber,
                Role = db.Roles.Find(applicationUser.Roles.FirstOrDefault().RoleId).Name,
                RolesList = allRoles.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
            };
            return View(userViewModel);
        }

        public ActionResult UpdateStatus(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            if (applicationUser.LockoutEnabled)
            {
                applicationUser.LockoutEnabled = false;
            }
            else
            {
                applicationUser.LockoutEnabled = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
        public JsonResult UsersDeleteWithAjax(string[] idArray)
        {
            foreach (string id in idArray)
            {
                ApplicationUser applicationUser = db.Users.Find(id);
                if (applicationUser != null && applicationUser.LockoutEnabled != true)
                {
                    applicationUser.LockoutEnabled = true;
                    db.Users.AddOrUpdate(applicationUser);
                }
            }
            db.SaveChanges();
            var data = "Success";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
