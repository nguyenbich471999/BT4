using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT4.Models
{
    public class Employee:Person
    {
        public String Company { get; set; }
        public string Address { get; set; }
    }
}