using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        public string UserName { get; set; }
    }
}