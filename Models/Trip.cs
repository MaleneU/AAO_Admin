using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required]
        [Display(Name = "Startdato og tid")]
        public DateTime StartDateAndTime { get; set; }

        [Display(Name = "Slutdato")]
        public DateTime StopDate { get; set; }
        
        [DisplayName("Varighed")]      
        public int Duration { get; set; }
        
        [Display(Name = "Kontaktperson")]
        public int UserID { get; set; }

        [Display(Name = "Kontaktperson")]
        public User User { get; set; }
        [Column(TypeName = "varchar(255)")]

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Display(Name = "Trafik")]
        public int TrafficID { get; set; }

        [Display(Name = "Trafik")]
        public Traffic Traffic { get; set; }

        [Display(Name = "Afdeling")]
        public int DepartmentID { get; set; }

        [Display(Name = "Afdeling")]
        public Department Department { get; set; }

        [Display(Name = "Startsted")]
        public int StartLocationID { get; set; }

        [Display(Name = "Startsted")]
        public StartLocation Startlocation { get; set; }

        [Display(Name = "Hastetur")]
        public bool Urgent { get; set; }

        [Display(Name = "Anmodninger")]
        public List<Request> Requests { get; set; }

        [NotMapped]
        [DisplayName("Startdato")]
        public string StartDate => StartDateAndTime.ToString("dd-MM-yyyy");
        [NotMapped]
        [DisplayName("Slutdato")]
        public string StopDateOnly => StopDate.ToString("dd-MM-yyyy");
        [NotMapped]
        [DisplayName("Starttid")]
        public string StartTime => StartDateAndTime.ToString("HH':'mm");

        
    }
}
