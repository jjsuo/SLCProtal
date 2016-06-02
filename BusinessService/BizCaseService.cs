/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/12 16:12:52 
** desc：  
** Ver : V1.0.0 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Common;
using Microsoft.Xrm.Sdk;

namespace BusinessService
{
    public class BizCaseService
    {
       
        /// <summary>
        /// 获取最近一次服务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public BizCase GetRecentBizCase(string userId)
        {
            ConvertClass<BizCase> convertClass = new ConvertClass<BizCase>();
            BizCase bizCase = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetRecentBizCase", new SqlParameter("@userId", userId));
            if (st.Tables[0].Rows.Count > 0)
            {
                bizCase = convertClass.ToT(st.Tables[0].Rows[0]);
            }

            return bizCase;
        }

        /// <summary>
        /// 获取最近一次服务的服务状态
        /// </summary>
        /// <param name="bizCaseId"></param>
        /// <returns></returns>
        public List<BizCaseStatus> GetBizCaseStatus(string bizCaseId)
        {
            ConvertClass<BizCaseStatus> convertClass = new ConvertClass<BizCaseStatus>();
            List<BizCaseStatus> bizCaseStatus = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetBizCaseStatus", new SqlParameter("@bizCaseId", bizCaseId));
            bizCaseStatus = convertClass.ToList(st.Tables[0]);

            return bizCaseStatus;
        }

        /// <summary>
        /// 获取专家列表
        /// </summary>
        /// <param name="bizCaseId"></param>
        /// <returns></returns>
        public List<Specialist> GetBizCaseSpecialist(string bizCaseId)
        {
            ConvertClass<Specialist> convertClass = new ConvertClass<Specialist>();
            List<Specialist> specialist = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetBizCaseSpecialist", new SqlParameter("@bizCaseId", bizCaseId));
            specialist = convertClass.ToList(st.Tables[0]);

            return specialist;
        }

        public List<BizCase> GetBizCases(string userId)
        {
            ConvertClass<BizCase> convertClass = new ConvertClass<BizCase>();
            List<BizCase> bizCases = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetBizCases", new SqlParameter("@userId", userId));
            bizCases = convertClass.ToList(st.Tables[0]);

            return bizCases;
        }

        public string ServiceScore(List<Score> scores ,string bizCaseId)
        {
            string message = "S";
            try
            {
                Entity entity = new Entity("slc_bizcase");

                foreach (var score in scores)
                {
                    entity["score" + score.Type] = score.ScoreCount.ToString();
                    entity["createscore" + score.Type] = DateTime.Now;
                }
                
                entity.Id = new Guid(bizCaseId);
                CrmService.OrgService.Update(entity);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
