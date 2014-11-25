using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using User.Service.Helpers;
using User.Service.Models;

namespace User.Service.Pipeline.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UserIdRequiredAttribute : AuthorizationFilterAttribute
    {
        public UserIdRequiredAttribute()
        {
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");

            if (SkipAuthorization(actionContext))
                return;

            if (!AuthorizeCore(actionContext.Request))
                HandleUnauthorizedRequest(actionContext);
        }

        private bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>() ||
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>();
        }

        private void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        private bool AuthorizeCore(HttpRequestMessage request)
        {
            return IsAuthorized(request);
        }

        private bool IsAuthorized(HttpRequestMessage request)
        {
            try
            {
                CookieHeaderValue cookie = request.Headers.GetCookies("AzuCookie").FirstOrDefault();

                if (cookie != null)
                {
                    //此处系统会自动UrlDecode
                    var token = cookie["AzuCookie"].Value;

                    var userId = 0L;

                    var isVerified = LocalUserTokenHelper.VerifyLocalToken(token, out userId);

                    if (isVerified)
                    {
                        AzUser.SetInApi(request, userId);
                    }

                    return isVerified;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}