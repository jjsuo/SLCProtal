using System.Web.Mvc;

namespace SLCProtal.Controllers
{
    public class HomeController : AuthenticationController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
    }
}