using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Web.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {

            return Content("123");
        }
    }
}