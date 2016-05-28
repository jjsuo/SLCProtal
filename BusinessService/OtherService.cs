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

namespace BusinessService
{
    public class OtherService
    {
        /// <summary>
        /// 创建问题
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public string CreateQA(string question,int type,string userid)
        {
            string result = "";
            try
            {
                Entity qa=new Entity("slc_qa");
                qa["subject"] = question;
                qa["slc_type"] = new OptionSetValue(type);
                qa["slc_contactid"] = new EntityReference("contact", new Guid(userid));
                CrmService.OrgService.Create(qa);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                
            }
            return result;
        }

        public List<QA> GetAllQA(int type, string userid)
        {
            ConvertClass<QA> convertClass = new ConvertClass<QA>();
            List<QA> qas = null;

            SqlParameter[] sps = new SqlParameter[2];
            sps[0] = new SqlParameter("@userid", userid);
            sps[1] = new SqlParameter("@type", type);
            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetQAByUserId", sps);
            qas = convertClass.ToList(st.Tables[0]);

            return qas;
        }
    }
}
