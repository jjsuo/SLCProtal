/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/12 16:29:31 
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
    public class Specialist
    {
        /// <summary>
        /// 专家名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 专家的域名称
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 专家的描述
        /// </summary>
        public string Description { get; set; }
    }
}
