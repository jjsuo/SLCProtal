using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace SLCProtal.Common
{
    public class SessionManage
    {
        public static Account AccountInfo
        {
            get
            {
                if (HttpContext.Current.Session["AccountInfo"] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session["AccountInfo"] as Account;
                }
            }
        }

        public static void SetAccountInfo(Account account)
        {
            HttpContext.Current.Session["AccountInfo"] = account;
        }

        internal static void Clear()
        {

            HttpContext.Current.Session["AccountInfo"] = null;
        }

    }
}