using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessEntities;
using BusinessService;
using SLCProtal.Common;
using SLCProtal.Models.Account;
using Common;

namespace SLCProtal.Controllers
{
    public class AccountController : BaseController
    {

        public ActionResult Login(string RedirectUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated
                && SessionManage.AccountInfo != null)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginModel oLoginModel = new LoginModel();

            oLoginModel.ReturnUrl = RedirectUrl;
            Response.AddHeader("Cache-Control", "no-cache,no-store");
            Response.AddHeader("Pragma", "no-cache");
            SessionManage.SetAccountInfo(null);
            if (Request.Cookies.AllKeys.Contains("username"))
            {
                oLoginModel.username = Request.Cookies["username"].Value;
            }
            if (Request.Cookies.AllKeys.Contains("password"))
            {
                oLoginModel.PassWord = Request.Cookies["password"].Value;
            }

            return View(oLoginModel);
        }


        //
        // GET: /Account/
        [HttpPost]
        public ActionResult Login(LoginModel oLoginModel)
        {

            AccountService service = new AccountService();
            Account account = service.CheckUser(oLoginModel.username, oLoginModel.PassWord);
            if (account != null)
            {

                SessionManage.SetAccountInfo(account);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, account.UserId, DateTime.Now, DateTime.Now.AddMinutes(Session.Timeout), false, account.UserId, FormsAuthentication.FormsCookiePath);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
                string redirectUrl = FormsAuthentication.GetRedirectUrl(account.UserId, false);
                //记住密码
                GetResponse GetRes = new GetResponse();
                if (oLoginModel.checkbox == "on")
                {
                    GetRes.addCookie("username", oLoginModel.username, 30);
                    GetRes.addCookie("password", oLoginModel.PassWord, 30);
                }
                else
                {
                    GetRes.clareCookie("username");
                    GetRes.clareCookie("password");
                }
                if (!string.IsNullOrEmpty(oLoginModel.ReturnUrl))
                {
                    return new RedirectResult("~" + oLoginModel.ReturnUrl);
                    // return RedirectToAction("index", "home");
                }
                else
                {
                    return RedirectToAction("index", "home");
                }
            }
            else
            {
                oLoginModel.PassWord = "";
                ViewData["error"] = "用户名或密码错误！";
                return View(oLoginModel);
            }
        }
        
    }
}
