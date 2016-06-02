/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/24 17:26:42 
** desc：  
** Ver : V1.0.0 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Visa
    {
        /// <summary>
        /// 签证人
        /// </summary>
        public string VisaUserIdName { get; set; }

        /// <summary>
        /// 签证状态
        /// </summary>
        public string VisaStatus { get; set; }

        /// <summary>
        /// 资料准备状态
        /// </summary>
        public string ZLStatus { get; set; }


        /// <summary>
        /// 地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
    }
}
