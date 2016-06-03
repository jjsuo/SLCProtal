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
    public class TransService
    {
        public List<Trans> GeTranses(string bizCaseId)
        {
            ConvertClass<Trans> convertClass = new ConvertClass<Trans>();
            List<Trans> transes = null;


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetTransByBizCase", new SqlParameter("@bizCaseId", bizCaseId));
            transes = convertClass.ToList(st.Tables[0]);

            return transes;
        }
    }
}
