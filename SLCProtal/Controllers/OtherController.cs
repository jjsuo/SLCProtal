using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessService;
using SLCProtal.Common;
using SLCProtal.Models.Other;

namespace SLCProtal.Controllers
{
    public class OtherController : AuthenticationController
    {
        //
        // GET: /Other/

        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult QandA()
        {
            QAModel qaModel=new QAModel();
            OtherService otherService=new OtherService();
            qaModel.Qas=otherService.GetAllQA(SessionManage.AccountInfo.UserId);
            return View(qaModel);
        }

        [HttpPost]
        public JsonResult CreateQA(QAModel qa)
        {
            OtherService otherService = new OtherService();
            string message= otherService.CreateQA(qa.Question, SessionManage.AccountInfo.UserId,
                SessionManage.BizCaseInfo.OwnerId);
            return Json(new { result = message });  
            //if (result != "S")
            //    ViewData["error"] = "出错了!";
            //return View("QandA", qa);
        }

       [HttpPost]
        public JsonResult CreateSuggestion(SuggestionModel model)
        {
            OtherService otherService = new OtherService();
            string message = otherService.CreateComplain(SessionManage.AccountInfo.UserId,
                model.Content,model.Type);
            return Json(new { result = message });  

            //if (result != "S")
            //{ 
            //    ViewData["error"] = "出错了!";
            //    return View("Suggestions", model);
            //}
            //return View("Suggestions", new SuggestionModel());
        }
       public ActionResult Suggestions()
       {
          
           return View(new SuggestionModel());
       }

      
    }
}
