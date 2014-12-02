using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Web.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            return RedirectToAction("VendorList");
        }

        public ActionResult VendorList()
        {
            return View();
        }
    }
}