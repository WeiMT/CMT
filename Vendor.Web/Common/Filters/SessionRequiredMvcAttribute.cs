using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vendor.Web.Common.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SessionRequiredMvcAttribute : ActionFilterAttribute
    {
        public SessionRequiredMvcAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (SkipAuthorization(filterContext))
                return;

            if (!AuthorizeCore(filterContext))
                HandleUnauthorizedRequest(filterContext);
        }
        private bool SkipAuthorization(ActionExecutingContext filterContext)
        {
            var allowAnonymous = false;

            var descriptor = filterContext.ActionDescriptor;
            if (!descriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                ControllerDescriptor controllerDescriptor = filterContext.ActionDescriptor.ControllerDescriptor;

                allowAnonymous = controllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            }
            else
            {
                allowAnonymous = true;
            }

            return allowAnonymous;
        }
        private void HandleUnauthorizedRequest(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Login",
                tip = "您还没有登录或登录已超时，请先登录"
            }));
        }

        private bool AuthorizeCore(ControllerContext filterContext)
        {
            //filterContext.Controller.
            try
            {
                var venderUser = (DataAccess.Models.VendorUser)HttpContext.Current.Session["VendorUser"];
                return venderUser != null && venderUser.Name != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}