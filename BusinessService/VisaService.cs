/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/24 17:28:22 
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

namespace BusinessService
{
    public class VisaService
    {
        public List<Visa> GetListVisaByBizCaseId(string bizCaseId)
        {
            ConvertClass<Visa> convertClass = new ConvertClass<Visa>();
            List<Visa> visas = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetVisaByCaseId", new SqlParameter("@bizCaseId", bizCaseId));
            visas = convertClass.ToList(st.Tables[0]);

            return visas;
        }
    }
}
