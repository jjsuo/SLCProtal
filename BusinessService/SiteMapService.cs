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
    public  class SiteMapService
    {

        public List<int> GetSitMap(string bizCaseId)
        {

            List<int> siteMaps = new List<int>();


            DataSet st = SqlHelper.ExecuteDataset(SqlConnect.CRM_ADDON_ConnectString, CommandType.StoredProcedure,
                "usp_protal_GetSitMap", new SqlParameter("@bizCaseId", bizCaseId));
            if (st.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in st.Tables[0].Rows)
                {
                    siteMaps.Add(Convert.ToInt32(dr["sitecount"]));
                }
                //siteMaps.Add(st.Tables[0].Rows[]);
            }

            return siteMaps;
        }

    }
}
