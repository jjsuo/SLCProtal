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


        public ActionResult Hotels()
        {
            HotelModel hotelModel = new HotelModel();
            BookService bookService = new BookService();
            hotelModel.Hotels = bookService.GetListHotelOrderByCaseId(SessionManage.BizCaseInfo.BizCaseId);
            return View(hotelModel);
        } 
    }
}
