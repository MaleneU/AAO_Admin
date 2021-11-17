using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class AvailabilityModel
    {
        public int AvailabilityID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public sbyte Status { get; set; }
        public int DriverID { get; set; }
    }
}
