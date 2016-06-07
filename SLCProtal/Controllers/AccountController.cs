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
        ////验证码
        //private string _code = "0000";

        ////用户的id，发送验证码中复制
        //private string _accountId = "";

       
        public ActionResult ChangePassword()
        {
            if (SessionManage.AccountInfo != null)

                ViewData["Phone"] = SessionManage.AccountInfo.Phone;
            else
                ViewData["Phone"] = "";
          
            return View();
        }
         
        //修改密码和忘记密码的区别在于 phone参数是否为空
        [HttpPost]
        public JsonResult ChangePassword(string code,string password)
         {
            if(Session["code"]==null||SessionManage.AccountInfo==null)
                return Json(new { result = "验证码过期!" });  

            var message = "";
              
            if (Session["code"].ToString() == code)
            {
                AccountService accountService=new AccountService();

                //如果已经登陆了，从Session中获取account的值
                accountService.ChangePassword(SessionManage.AccountInfo.UserId, password);
                message = "S";
            }
            else
            {
                ViewData["error"] = "验证码错误！";
                message = "E";
            }
            return Json(new { result = message });  
        }

        [HttpPost]
        public JsonResult SendPassWord(string phone)
        {


            Random rad = new Random(); //实例化随机数产生器rad；
            string code = rad.Next(1000, 10000).ToString(); //用rad生成大于等于1000，小于等于9999的随机数；

            AccountService accountService = new AccountService();
            string message = accountService.SendCode(phone, code.ToString());
            if (message == "E")
            {
                //_accountId = message;
                return Json(new {result = message});
            }
            else
            {
                if (SessionManage.AccountInfo == null)
                {
                    Account account = new Account() {UserId = message};
                    SessionManage.SetAccountInfo(account);
                }
                Session["code"] = code;
                return Json(new {result = "S"});
            }
        }

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


        public ActionResult Logout()
        {
            HttpContext.Session.Abandon();
            SessionManage.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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
