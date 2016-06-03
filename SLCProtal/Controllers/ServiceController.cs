using BusinessService;
using SLCProtal.Common;
using SLCProtal.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLCProtal.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        /// <summary>
        /// 服务信息页
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceInfo()
        {
            ServiceInfoModel serviceInfoModel=new ServiceInfoModel();
            BizCaseService bizCaseService=new BizCaseService();
            ServiceItemService service=new ServiceItemService();
            serviceInfoModel.BizCases = bizCaseService.GetBizCases(SessionManage.AccountInfo.UserId);
            serviceInfoModel.ServiceItems = service.GetServiceItemByBizCase(SessionManage.BizCaseInfo.BizCaseId);
            return View(serviceInfoModel);
        }

        /// <summary>
        /// 翻译页
        /// </summary>
        /// <returns></returns>
        public ActionResult Translation()
        {
            TransModel transModel=new TransModel();
            TransService service=new TransService();
            transModel.Transes = service.GeTranses(SessionManage.BizCaseInfo.BizCaseId);
            return View(transModel);
        }

        /// <summary>
        /// 签证页
        /// </summary>
        /// <returns></returns>
        public ActionResult Visa()
        {
            VisaModel visaModel=new VisaModel();
            VisaService visaService=new VisaService();
            visaModel.Visas = visaService.GetListVisaByBizCaseId(SessionManage.BizCaseInfo.BizCaseId);
            return View(visaModel);
        }

        /// <summary>
        /// 海外服务
        /// </summary>
        /// <returns></returns>
        public ActionResult OverseasService()
        {
            OverSeaServiceItemModel model=new OverSeaServiceItemModel();
            ServiceItemService service=new ServiceItemService();
            model.OverseaServiceItems = service.GetOverSeaServiceItemByBizCase(SessionManage.BizCaseInfo.BizCaseId);
            return View(model);
        }

        /// <summary>
        /// 机票页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Flights()
        {
            PlanModel planModel = new PlanModel();
            BookService bookService = new BookService();
            planModel.Flights = bookService.GetListPlanOrderByCaseId(SessionManage.BizCaseInfo.BizCaseId);
            return View(planModel);
        }

        /// <summary>
        /// 酒店页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Hotels()
        {
            HotelModel hotelModel = new HotelModel();
            BookService bookService = new BookService();
            hotelModel.Hotels = bookService.GetListHotelOrderByCaseId(SessionManage.BizCaseInfo.BizCaseId);
            return View(hotelModel);
        }

        /// <summary>
        /// 预约页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Reservation()
        {
            OrderModel orderModel = new OrderModel();
            OrderService orderService = new OrderService();
            orderModel.Orders = orderService.GetListOrderByCaseId(SessionManage.BizCaseInfo.BizCaseId);
            return View(orderModel);
        }


        //接机送机分别为俩页
        public ActionResult PickUps(int type)
        {
            PickModel pickModel=new PickModel();
            BookService bookService=new BookService();
            pickModel.PicklList = bookService.GetListPeoplesByCaseId(SessionManage.BizCaseInfo.BizCaseId,
                type);

            return View(pickModel);
        }

        /// <summary>
        /// 评分叶
        /// </summary>
        /// <param name="scoreModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Scores(ScoreModel scoreModel)
        {
            BizCaseService bizCaseService=new BizCaseService();
            string message= bizCaseService.ServiceScore(scoreModel.Scores, SessionManage.BizCaseInfo.BizCaseId);

            return Json(new { result = message });  
        }

        public ActionResult Scores()
        {
            return View();
        }

       // public 
    }
}
