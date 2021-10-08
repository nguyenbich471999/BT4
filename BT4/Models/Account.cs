using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BT4.Models
{
    public class Account
    {
        [Key]
        public string UserName { get; set; }
        [Required(ErrorMessage ="tai khoan khong chinh xac")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Stringlength(10)]
        public string RoleID { get; set; }
    }
}