using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace SLCProtal.Models.Service
{
    public class ServiceInfoModel
    {
        public List<BizCase> BizCases { get; set; }

        public List<ServiceItem> ServiceItems { get; set; } 
    }
}