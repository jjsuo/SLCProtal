using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace SLCProtal.Models.Home
{
    public class AccountInfoModel
    {
        public BusinessEntities.Account Account { get; set; }

        public SickPeople Sick { get; set; }
    }
}