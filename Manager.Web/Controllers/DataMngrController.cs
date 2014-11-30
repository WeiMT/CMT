using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Web.Controllers
{
    public class DataMngrController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("CarType");
        }

        public ActionResult CarType()
        {
            return View();
        }
    }
}