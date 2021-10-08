using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT4.Models
{
    public class Role
    {
       
        [key]
        [Stringlength(10)]
        public string RoleID { get; set; }
        [Stringlength(50)]
        public string RoleName { get; set; }
    }
}