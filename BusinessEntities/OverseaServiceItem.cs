using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class OverseaServiceItem:ServiceItem
    {
        /// <summary>
        /// 服务项目
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务内容
        /// </summary>
        public string ServiceContent { get; set; }


        /// <summary>
        /// 单位计数
        /// </summary>
        public string ServiceTime { get; set; }

        /// <summary>
        /// 服务剩余
        /// </summary>
        public string ServiceLeft { get; set; }
    }
}
