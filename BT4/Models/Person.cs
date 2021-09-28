using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT4.Models
{
    public class Person
    {
        public string PersonID { get; set; }
        [AllowHtml]
        public string PersonName { get; set; }
    }
}