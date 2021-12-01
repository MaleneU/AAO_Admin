using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class TripModel
    {
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Urgent { get; set; }
        public string DepartmentName { get; set; }
        public string FullName { get; set; }
        public string Traffic { get; set; }
        public int TripID { get; set; }

    }
}
