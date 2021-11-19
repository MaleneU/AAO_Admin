using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public bool Active { get; set; }
        public StartLocation StartLocation { get; set; }
        public TrafficType TrafficType { get; set; }
    }
}
