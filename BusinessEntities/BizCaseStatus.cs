/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/12 16:16:21 
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
    public class BizCaseStatus
    {

        /// <summary>
        /// 对应的实体名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应的实体状态
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 对应的状态的显示名称
        /// </summary>
        public string Value { get; set; }
    }
}
