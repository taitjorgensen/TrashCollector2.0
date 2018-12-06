using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class PickUpDays
    {
        [Key]
        public int DayId { get; set; }

        public string dayOfWeek { get; set; }
    }
}