/********************************************************************************
** Copyright(c) 2016  All Rights Reserved. 
** auth：索俊杰
** mail：suojunjie@hotmail.com
** date： 2016/5/9 23:29:04 
** desc：  
** Ver : V1.0.0 
*********************************************************************************/

namespace BusinessEntities
{
    public class SickPeople 
    {
        public string UserId { get; set; }

        //用户名
        public string UserName { get; set; }



        //性别
        public string Gendercode { get; set; }

        //证件类型
        public string Certype { get; set; }

        //证件号码
        public string Governmentid { get; set; }


        //联系方式
        public string Phone { get; set; }

        //联系方式
        public string Phone1 { get; set; }

        //地址
        public string Address { get; set; }

        public string SickName { get; set; }

        public string Remark { get; set; }
    }
}