using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    /// <summary>
    /// 翻译
    /// </summary>
    public class Trans
    {
        /// <summary>
        /// 翻译人
        /// </summary>
        public string TranslateuseridName { get; set; }

        /// <summary>
        /// 翻译状态
        /// </summary>
        public string Translatestatus { get; set; }

        /// <summary>
        /// 发起时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
    }
}
