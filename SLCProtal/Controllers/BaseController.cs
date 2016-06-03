using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Common;
using SLCProtal.Common;

namespace SLCProtal.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                return;
            }

            filterContext.ExceptionHandled = true;

            try
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];

                //跳转到错误页面
                HandleErrorInfo oHandleErrorInfo = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                LogHelper.Error(filterContext.Exception.Message + filterContext.Exception.StackTrace);
                var method = typeof(ControllerActionInvoker).GetMethod("GetControllerDescriptor", BindingFlags.Instance | BindingFlags.NonPublic);
                var controllerDescriptor = (ControllerDescriptor)method.Invoke(this.ActionInvoker, new object[] { this.ControllerContext }); ;
                var actionDescriptor = controllerDescriptor.FindAction(this.ControllerContext, actionName);
                bool isDataActionResult = false;
                if (actionDescriptor != null)
                {
                    isDataActionResult = actionDescriptor.IsDefined(typeof(ActionTypeAttribute), false);
                }

                //如果未定义特性，则返回到 Error View
                if (!isDataActionResult)
                {
                    if (HttpContext.User.Identity.IsAuthenticated)
                        filterContext.Result = View("Error", oHandleErrorInfo);
                    else
                        filterContext.Result = PartialView("Error", oHandleErrorInfo);
                }
                else
                {
                    filterContext.Result = Json(new { Failed = true, Message = filterContext.Exception.Message }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
            }

            base.OnException(filterContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                HandleErrorInfo oHandleErrorInfo = new HandleErrorInfo(new Exception("Http 403, 禁止执行访问。 如果问题依然存在，请与 Web 服务器的管理员联系。"), controllerName, actionName);
                if (HttpContext.User.Identity.IsAuthenticated)
                    filterContext.Result = View("Error", oHandleErrorInfo);
                else
                    filterContext.Result = PartialView("Error", oHandleErrorInfo);
            }
          

            base.OnActionExecuting(filterContext);
        }

        //protected override ViewResult View(string viewName, string masterName, object model)
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo != null && BaseModel.DealerInfo != null)
        //    {
        //        ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
        //    }

        //    return base.View(viewName, masterName, model);
        //}
        //protected override PartialViewResult PartialView(string viewName, object model)
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo != null && BaseModel.DealerInfo != null)
        //    {
        //        ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
        //    }
        //    return base.PartialView(viewName, model);
        //}
        //protected override ViewResult View(IView view, object model)
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo!=null && BaseModel.DealerInfo!=null)
        //    {
        //        ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
        //    }
        //    return base.View(view, model);
        //}
        //protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues)
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo != null && BaseModel.DealerInfo != null)
        //    {
        //        ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
        //    }
        //    return base.RedirectToAction(actionName, controllerName, routeValues);
        //}
        //protected override RedirectToRouteResult RedirectToRoute(string routeName, System.Web.Routing.RouteValueDictionary routeValues)
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo != null && BaseModel.DealerInfo != null)
        //    {
        //        ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
        //    }
        //    return base.RedirectToRoute(routeName, routeValues);
        //}
        //protected override RedirectResult Redirect(string url)
        //{
        //    if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo != null && BaseModel.DealerInfo != null)
        //    {
        //        ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
        //    }
        //    return base.Redirect(url);
        //}
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //if (HttpContext.User.Identity.IsAuthenticated && BaseModel.UserInfo != null && BaseModel.DealerInfo != null)
            //{
            //    ViewData["UserName"] = BaseModel.UserInfo.DisplayName;
            //}
            base.OnActionExecuted(filterContext);
        }

    }
}
