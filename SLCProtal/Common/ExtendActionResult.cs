using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLCProtal.Common
{

  



    public class UnAuthenticationResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = 405;
            response.Write("没有权限访问!");
        }
    }
}