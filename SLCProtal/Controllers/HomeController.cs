using BusinessEntities;
using BusinessService;
using SLCProtal.Common;
using SLCProtal.Models.Home;
using System;
using System.Web.Mvc;

namespace SLCProtal.Controllers
{
    public class HomeController : AuthenticationController
    {
        public ActionResult Index()
        {
            BizCaseService bizCaseService = new BizCaseService();
            ServiceItemService serviceItemService = new ServiceItemService();
            HomeModel home = new HomeModel();
            string message = string.Empty;

            home = GetHomeModel(out message);

            MainModel main = new MainModel();
            main.SiteMaps = home.SiteMaps;
            main.Status = home.Status;
            main.ServiceItems = serviceItemService.GetServiceItemByBizCase(SessionManage.BizCaseInfo.BizCaseId);
            main.Specialist = bizCaseService.GetBizCaseSpecialist(SessionManage.BizCaseInfo.BizCaseId);

            if (!string.IsNullOrEmpty(message))
                ViewData["error"] = message;
            return View(main);
        }
        public ActionResult Main()
        {
            HomeModel home = new HomeModel();
            string message=string.Empty;

            home = GetHomeModel(out message);
            ViewData["UserName"] = SessionManage.AccountInfo.UserName;
            if(!string.IsNullOrEmpty(message))
                ViewData["error"] = message;
            return View(home);
        }

        private HomeModel GetHomeModel(out string message)
        {
            message = "";
            HomeModel home = new HomeModel();
            BizCaseService bizCaseService = new BizCaseService();
            BizCase bizCase= bizCaseService.GetRecentBizCase(SessionManage.AccountInfo.UserId);
            if (bizCase == null)
                message = "没有最近一次服务!";

            SessionManage.SetBizCaseInfo(bizCase);
            SiteMapService smService = new SiteMapService();
            home.SiteMaps = smService.GetSitMap(SessionManage.BizCaseInfo.BizCaseId);
            home.Status = bizCase.Status;
            return home;

        }
     
    }
}