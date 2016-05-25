﻿using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class BookService
    {
        public List<HotelBook> GetListHotelOrderByCaseId(string bizCaseId)
        {
            ConvertClass<HotelBook> convertClass = new ConvertClass<HotelBook>();
            List<HotelBook> hotelOrder = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetHotelOrderByCaseId", new SqlParameter("@bizCaseId", bizCaseId));
            hotelOrder = convertClass.ToList(st.Tables[0]);

            return hotelOrder;
        }

        public List<PlanBook> GetListHotelOrderByCaseId(string bizCaseId)
        {
            ConvertClass<PlanBook> convertClass = new ConvertClass<PlanBook>();
            List<PlanBook> planBook = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetPlanOrderByCaseId", new SqlParameter("@bizCaseId", bizCaseId));
            planBook = convertClass.ToList(st.Tables[0]);

            return planBook;
        }
    }
}
