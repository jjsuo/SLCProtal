/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/24 10:12:17 
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
    public class OrderService
    {
        public static List<Order> GetListOrderByCaseId(string bizCaseId)
        {
            ConvertClass<Order> convertClass = new ConvertClass<Order>();
            List<Order> orders = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetOrderByCaseId", new SqlParameter("@bizCaseId", bizCaseId));
            orders = convertClass.ToList(st.Tables[0]);

            return orders;
        }
    }
}
