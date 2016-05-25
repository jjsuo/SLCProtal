using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PlanBook
    {
        /// <summary>
        /// 航班号
        /// </summary>
        public string flightno { get; set; }

        /// <summary>
        /// 航空公司
        /// </summary>
        public string tripcompany { get; set; }

        /// <summary>
        /// 出发机场
        /// </summary>
        public string fromport { get; set; }


        /// <summary>
        /// 降落机场 
        /// </summary>
        public string toport { get; set; }


        /// <summary>
        /// 出发时间
        /// </summary>
        public string fromtime { get; set; }

        /// <summary>
        /// 降落时间
        /// </summary>
        public string totime { get; set; }
    }
}
