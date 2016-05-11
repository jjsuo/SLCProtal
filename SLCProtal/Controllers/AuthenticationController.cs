using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SLCProtal.Controllers
{
    public class AuthenticationController : BaseController
    {
        //
        // GET: /Authentication/

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var applicationPath = filterContext.HttpContext.Request.ApplicationPath;
                var rawUrl = filterContext.HttpContext.Request.RawUrl;
                var redirectUrl = rawUrl;
                if (rawUrl.StartsWith(applicationPath))
                {
                    redirectUrl = rawUrl.Substring(applicationPath.Length);
                    if (!redirectUrl.StartsWith("/"))
                    {
                        redirectUrl = "/" + redirectUrl;
                    }
                }

                string loginUrl = FormsAuthentication.LoginUrl + string.Format("?RedirectUrl={0}", redirectUrl);
                filterContext.Result = new RedirectResult(loginUrl);
            }

            base.OnActionExecuting(filterContext);
        }

    }
}
