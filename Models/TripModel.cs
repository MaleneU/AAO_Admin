using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class TripModel
    {

        [Key]
        public int TripID { get; set; }
        
        public DateTime StartDateAndTime { get; set; }

        public DateTime StopDate { get; set; }

        public int Duration { get; set; }

        public int ContactID { get; set; }

        public string DescriptionOfTrip { get; set; }

        public int TrafficID { get; set; }

        public int DepartmentID { get; set; }

        public int StatusID { get; set; }
        public int TypeID { get; set; }


        public class AAO_AdminPanelContext : DbContext
        {
            public DbSet<TripModel> Trips { get; set; }
        }

    }
}
