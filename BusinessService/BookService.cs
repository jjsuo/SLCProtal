using BusinessEntities;
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

        public List<PlanBook> GetListPlanOrderByCaseId(string bizCaseId)
        {
            ConvertClass<PlanBook> convertClass = new ConvertClass<PlanBook>();
            List<PlanBook> planBook = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetPlanOrderByCaseId", new SqlParameter("@bizCaseId", bizCaseId));
            planBook = convertClass.ToList(st.Tables[0]);

            return planBook;
        }


        public List<PickPeople> GetListPeoplesByCaseId(string bizCaseId,int type)
        {
            ConvertClass<PickPeople> convertClass = new ConvertClass<PickPeople>();
            List<PickPeople> pickPeoples = null;

            SqlParameter[] sps = new SqlParameter[2];
            sps[0] = new SqlParameter("@bizCaseId", bizCaseId);
            sps[1] = new SqlParameter("@type", type);

            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetListPeoplesByCaseId", sps);
            pickPeoples = convertClass.ToList(st.Tables[0]);

            return pickPeoples;
        }
    }
}
