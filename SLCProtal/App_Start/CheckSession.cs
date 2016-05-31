using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SLCProtal.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MyAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var account = filterContext.HttpContext.Session["AccountInfo"];
            var bizCase = filterContext.HttpContext.Session["BizCaseInfo"];
            //When user has not login yet
            if (account == null || bizCase == null)
            {
                var redirectUrl = FormsAuthentication.LoginUrl + "?RedirectPath=" +
                                  filterContext.HttpContext.Request.Url;
                if (!filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new RedirectResult(redirectUrl);
                }
                else
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Success = false,
                            Message = string.Empty,
                            Redirect = redirectUrl
                        }
                    };
                }
                return;
            }
        }
    }
}