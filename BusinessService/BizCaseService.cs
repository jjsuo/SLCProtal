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

        /// <summary>
        /// 获取历史服务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BizCaseDetail> GetBizCases(string userId)
        {
            ConvertClass<BizCaseDetail> convertClass = new ConvertClass<BizCaseDetail>();
            List<BizCaseDetail> bizCases = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetBizCases", new SqlParameter("@userId", userId));
            bizCases = convertClass.ToList(st.Tables[0]);

            return bizCases;
        }

        /// <summary>
        /// 服务评分
        /// </summary>
        /// <param name="scores"></param>
        /// <param name="bizCaseId"></param>
        /// <returns></returns>
        public string ServiceScore(List<Score> scores ,string bizCaseId)
        {
            string message = "S";
            try
            {
                Entity entity = new Entity("slc_bizcase");

                foreach (var score in scores)
                {
                    entity["slc_score" + score.Type] = score.ScoreCount.ToString();
                    entity["slc_createscore" + score.Type] = DateTime.Now;
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

        public List<Score> GetScores(string bizCaseId)
        {
            ConvertClass<Score> convertClass = new ConvertClass<Score>();
            List<Score> scores = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetScores", new SqlParameter("@bizCaseId", bizCaseId));
            scores = convertClass.ToList(st.Tables[0]);

            return scores;
        }

        public BizCaseDetail GetBizCaseDetail(string bizCaseId)
        {
            ConvertClass<BizCaseDetail> convertClass = new ConvertClass<BizCaseDetail>();
            BizCaseDetail bizCaseDetail = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetBizCaseDetail", new SqlParameter("@bizCaseId", bizCaseId));
            if (st.Tables[0].Rows.Count < 0) return null;
            bizCaseDetail = convertClass.ToT(st.Tables[0].Rows[0]);

            return bizCaseDetail;
        }
    }
}
