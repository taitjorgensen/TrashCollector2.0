using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public string PickUpDay { get; set; }
        public double? BalanceDue { get; set; }
        public DateTime? ExtraPickUp { get; set; }
        public DateTime? StartSuspendService { get; set; }
        public DateTime? EndSuspendService { get; set; }
        public bool hasBeenPickedUp { get; set; }
    }
}