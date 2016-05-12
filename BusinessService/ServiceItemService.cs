/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/12 23:06:54 
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
    public  class ServiceItemService
    {
        public List<ServiceItem> GetServiceItemByBizCase(string bizCaseId)
        {
            ConvertClass<ServiceItem> convertClass = new ConvertClass<ServiceItem>();
            List<ServiceItem> serviceItems = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetServiceItemByBizCase", new SqlParameter("@bizCaseId", bizCaseId));
            serviceItems = convertClass.ToList(st.Tables[0]);

            return serviceItems;
        }
    }
}
