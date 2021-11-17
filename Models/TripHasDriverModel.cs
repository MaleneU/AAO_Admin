using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class TripHasDriverModel
    {
        [Key]
        public int DriverID { get; set; }
        public int TripID { get; set; }
    }
}
