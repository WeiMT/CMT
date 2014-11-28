using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vendor.Web.Controllers
{
    public class HomeController : Controller
    {
        public DataAccess.Models.VendorUser VendorUser { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TranComplete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TranComplete([Bind(Include = "CustomerCellphone, CustomCarNo")] DataAccess.Models.VendorOrder order)
        {
            return View(order);
        }
        public ActionResult TranPay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TranPay([Bind(Include = "CustomerCellphone, CustomCarNo")] DataAccess.Models.VendorOrder order)
        {
            return View(order);
        }
        public ActionResult TranItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TranItem([Bind(Include = "CustomerCellphone, CustomCarNo")] DataAccess.Models.VendorOrder order)
        {
            return View(order);
        }


        public ActionResult TranReg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TranReg([Bind(Include = "CustomerCellphone, CustomCarNo")] DataAccess.Models.VendorOrder order)
        {
            System.Web.HttpContext.Current.Session["order"] = order;
            return Redirect("~/Home/TranItem");
        }


        [AllowAnonymous]
        public ActionResult Login(string tip = "")
        {
            ViewBag.Tip = tip;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Name, Password")] DataAccess.Models.VendorUser vendorUser)
        {
            
            using (var ctx = new DataAccess.Models.CarHealthEntities())
            {
                var vendorUsers =
                    ctx.VendorUsers.Where(x => x.Name.ToLower() == vendorUser.Name.ToLower() && x.Password == vendorUser.Password).ToList();

                if (vendorUsers.Count == 0)
                {
                    ViewBag.Tip = "您输的用户名或密码不正确，请重新输入";
                    return View();
                }
                vendorUser = vendorUsers[0];

                System.Web.HttpContext.Current.Session["VendorUser"] = vendorUser;

                return Redirect("~/Home");
            }
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["VendorUser"] = null;

            return Redirect("~/Home/Login");
        }
    }
}