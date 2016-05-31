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
                //Account account = new Account();
                //account.UserId = "406e73a7-4001-e611-819b-000c293cbef6";
                //return account;
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
            HttpContext.Current.Session["BizCaseInfo"] = null;
            HttpContext.Current.Session["AccountInfo"] = null;
        }



        public static BizCase BizCaseInfo
        {
            get
            {
                BizCase bc = new BizCase();
                bc.BizCaseId = "7675b10b-f70a-e611-81af-000c29de43e6";
                return bc;
                if (HttpContext.Current.Session["BizCaseInfo"] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session["BizCaseInfo"] as BizCase;
                }
            }
        }



        public static void SetBizCaseInfo(BizCase bizCase)
        {
            HttpContext.Current.Session["BizCaseInfo"] = bizCase;
        }


    }
}