using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Trip
    {

        [Key]
        public int TripID { get; set; }
        
        public DateTime StartDateAndTime { get; set; }

        public DateTime StopDate { get; set; }

        public int Duration { get; set; }


        // Kontakt
        public User User { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        public Traffic Traffic { get; set; }

        public Department Department { get; set; }
        public StartLocation Startlocation { get; set; }

        public bool Urgent { get; set; }

        public List<Request> Requests { get; set; }


        public class AAO_AdminPanelContext : DbContext
        {
            public DbSet<Trip> Trips { get; set; }
        }

    }
}
