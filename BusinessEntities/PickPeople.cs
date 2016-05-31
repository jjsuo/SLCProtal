using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PickPeople
    {
        /// <summary>
        /// 接洽地点
        /// </summary>
        public string pickaddress { get; set; }

        /// <summary>
        /// 送达地点
        /// </summary>
        public string sendaddress { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public string ordertime { get; set; }

        /// <summary>
        /// 接送人
        /// </summary>
        public string pickperson { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string pickphone { get; set; }

        /// <summary>
        /// 服务状态
        /// </summary>
        public string pickstate { get; set; }
    }
}
