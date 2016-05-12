/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/12 16:19:49 
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
    public class ServiceItem
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
    }
}
