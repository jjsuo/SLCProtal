using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLCProtal.Common
{
    public class ActionTypeAttribute:Attribute
    {
        public string Name { get; set; }

        public ActionTypeAttribute()
        {
            Name = "Data";
        }
        public ActionTypeAttribute(string name)
        {
            Name = name;
        }
    }
   
}