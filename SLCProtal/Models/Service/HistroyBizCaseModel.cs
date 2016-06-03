using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace SLCProtal.Models.Service
{
    public class HistroyBizCaseModel
    {
        public List<ServiceItem> ServiceItems { get; set; }

        public BizCaseDetail BizCaseDetail { get; set; }
    }
}