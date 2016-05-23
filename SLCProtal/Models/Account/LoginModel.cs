using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLCProtal.Models.Account
{
    public class LoginModel
    {
        [DisplayName("用户名")]
        [Required]
        public string username { get; set; }

        [DisplayName("密码")]
        [Required]
        public string PassWord { get; set; }
        public string checkbox { get; set; }
        public string ReturnUrl { get; set; }
    }
}