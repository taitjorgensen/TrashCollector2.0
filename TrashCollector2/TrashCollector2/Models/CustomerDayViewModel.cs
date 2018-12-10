using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class CustomerDayViewModel
    {
        public string PickUpDay { get; set; }
        public IEnumerable<Customers> Customers { get; set; }
    }
}