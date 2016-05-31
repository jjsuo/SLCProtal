using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Common;
using Microsoft.Xrm.Sdk;

namespace BusinessService
{
    public class AccountService
    {
        /// <summary>
        /// 根据账户名和密码来检测用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public Account CheckUser(string userName, string passWord)
        {
            ConvertClass<Account> convertClass = new ConvertClass<Account>();
            Account user = null;
            //Account user = new Account();
            //user.UserId = Guid.NewGuid().ToString();
            //return user;
            SqlParameter[] sps = new SqlParameter[2];
            sps[0] = new SqlParameter("@loginname", userName);
            sps[1] = new SqlParameter("@password", passWord);
            DataSet st = new DataSet();
            st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_checkuser", sps);
            if (st.Tables[0].Rows.Count > 0)
            {
                user = convertClass.ToT(st.Tables[0].Rows[0]);

            }

            return user;

            //DataSet ds = SqlHelper.ExecuteDataset(SqlConnect.CRM_MSCRM_ConnectString, CommandType.Text,
            //"SELECT * from account where getdate() between expires_from and expires_to");

            //return userName == "admin" && passWord == "123456";
        }

        /// <summary>
        /// 根据userID获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Account GetUser(string userId)
        {
            ConvertClass<Account> convertClass = new ConvertClass<Account>();
            Account user = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetUserInfo", new SqlParameter("@userId", userId));
            if (st.Tables[0].Rows.Count > 0)
            {
                user = convertClass.ToT(st.Tables[0].Rows[0]);
            }

            return user;
        }

        /// <summary>
        /// 根据手机号来检测用户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Account CheckUser(string phone)
        {
            ConvertClass<Account> convertClass = new ConvertClass<Account>();
            Account user = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_CheckUserByPhone", new SqlParameter("@phone", phone));
            if (st.Tables[0].Rows.Count > 0)
            {
                user = convertClass.ToT(st.Tables[0].Rows[0]);
            }

            return user;
        }

        /// <summary>
        /// 获取患者信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SickPeople GetSickPeople(string userId)
        {
            ConvertClass<SickPeople> convertClass = new ConvertClass<SickPeople>();
            SickPeople sickPeople = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetSickPeople", new SqlParameter("@userId", userId));
            if (st.Tables[0].Rows.Count > 0)
            {
                sickPeople = convertClass.ToT(st.Tables[0].Rows[0]);
            }

            return sickPeople;
        }

        /// <summary>
        /// 发送验证码，如果成功返回客户的guid，如果失败返回E
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string SendCode(string phone,string code)
        {
            string userId;
            Account account = CheckUser(phone);

            if (account == null)
                return "E";
            else
            {
                userId = account.UserId;
            }

            Entity letter = new Entity("letter");
            letter["slc_tonumber"] = phone;
            letter["to"] = new EntityReference("contact", new Guid(userId));
            letter["slc_messagetype"] = new OptionSetValue(4);
            letter["subject"] = "修改密码通知短信";

            letter["slc_content"] = code.ToString(CultureInfo.InvariantCulture);
            CrmService.OrgService.Create(letter);
            return account.UserId.ToString();
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public void ChangePassword(string userid,string newPassword)
        {
            Entity contact=new Entity("contact");
            contact["slc_password"] = newPassword;
            CrmService.OrgService.Update(contact);
           
        }
    }
}
