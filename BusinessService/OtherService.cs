using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.Xrm.Sdk;
using BusinessEntities;
using Microsoft.Xrm.Sdk.Messages;

namespace BusinessService
{
    public class OtherService
    {
        /// <summary>
        /// 创建问题
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public string CreateQA(string question,string userid,string owernid)
        {
            string result = "S";
            try
            {
                Entity qa=new Entity("slc_qa");
                qa["subject"] = question;
               qa["ownerid"]=new EntityReference("systemuser",new Guid(owernid));
                qa["slc_contactid"] = new EntityReference("contact", new Guid(userid));
                CrmService.OrgService.Create(qa);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                
            }
            return result;
        }

        public List<QA> GetAllQA(string userid)
        {
            ConvertClass<QA> convertClass = new ConvertClass<QA>();
            List<QA> qas = null;

            //SqlParameter[] sps = new SqlParameter[2];
            //sps[0] = new SqlParameter("@userid", userid);
          
            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetQAByUserId", new SqlParameter("@userid", userid));
            qas = convertClass.ToList(st.Tables[0]);

            return qas;
        }

        /// <summary>
        /// 创建投诉和建议 1是投诉，2是建议
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string CreateComplain(string userid,string content,int type)
        {
            string result = "S";
            try
            {
                Entity complain = new Entity("slc_complaint");
                complain["slc_content"] = content;
                complain["slc_type"] = new OptionSetValue(type);
                complain["slc_contactid"] = new EntityReference("contact", new Guid(userid));
                CrmService.OrgService.Create(complain);
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }
    }
}
