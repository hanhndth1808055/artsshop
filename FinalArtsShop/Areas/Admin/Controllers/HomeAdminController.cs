using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
