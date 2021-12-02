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
        
        [Display(Name = "Startdato og tid")]
        public DateTime StartDateAndTime { get; set; }

        [Display(Name = "Stop dato")]
        public DateTime StopDate { get; set; }

        [Display(Name = "Varighed")]
        public int Duration { get; set; }
        public int UserID { get; set; }

        [Display(Name = "Chauffør")]
        public User User { get; set; }
        [Column(TypeName = "varchar(255)")]

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        public int TrafficID { get; set; }

        [Display(Name = "Traffik")]
        public Traffic Traffic { get; set; }
        public int DepartmentID { get; set; }

        [Display(Name = "Afdeling")]
        public Department Department { get; set; }


        public int StartLocationID { get; set; }

        [Display(Name = "Start Lokation")]
        public StartLocation Startlocation { get; set; }

        [Display(Name = "Haste tur")]
        public bool Urgent { get; set; }
        public List<Request> Requests { get; set; }


    }
}
