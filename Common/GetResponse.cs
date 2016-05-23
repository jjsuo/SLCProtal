using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Common
{
    public class GetResponse
    {
        public HttpContext context;
        public GetResponse()
        {
            context = HttpContext.Current;
        }
        public void clareCookie(string name)
        {

            HttpCookie cok = context.Request.Cookies[name];
            TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
            cok.Expires = DateTime.Now.Add(ts);
            context.Response.AppendCookie(cok);
        }
        public void addCookie(string name, string value, int expiration = 0)
        {

            var setCookie = (new HttpCookie(name, value));
            setCookie.Domain = FormsAuthentication.CookieDomain;
            if (expiration > 0)
                setCookie.Expires = DateTime.Now.AddDays(expiration);

            context.Response.Cookies.Add(setCookie);
        }
    }
}
