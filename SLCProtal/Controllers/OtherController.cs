using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLCProtal.Controllers
{
    public class OtherController : Controller
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

    }
}
