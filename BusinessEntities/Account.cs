﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Account
    {
        public string UserId { get; set; }


        public string LoginName { get; set; }

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
    }
}
