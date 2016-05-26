using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLCProtal.Models.Home
{
    public class MainModel:HomeModel
    {
        public List<ServiceItem> ServiceItems { get; set; }

        public List<Specialist> Specialist { get; set; }
    }
}