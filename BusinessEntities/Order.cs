/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/24 10:12:03 
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
     public class Order
    {
         /// <summary>
         /// 国家
         /// </summary>
         public string Country { get; set; }
         /// <summary>
         /// 医院
         /// </summary>
         public string Hospital { get; set; }

         /// <summary>
         /// 专家
         /// </summary>
         public string Abroaddoctor { get; set; }

         /// <summary>
         /// 疾病
         /// </summary>
         public string Disease { get; set; }

         /// <summary>
         /// 就诊日期
         /// </summary>
         public string Starttime { get; set; }
    }
}
