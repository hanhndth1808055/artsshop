using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class TestThemeController : Controller
    {
        // GET: TestTheme
        public ActionResult IndexBackend()
        {
            return View("~/Views/Backend/Dashbroad.cshtml");
        }

        public ActionResult DemoForm()
        {
            return View("~/Views/Backend/DemoForm2.cshtml");
        }

        public ActionResult DemoDatatable()
        {
            return View("~/Views/Backend/DemoDatatable.cshtml");
        }

    }
}