﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Availability
    {
        [Key]
        public int AvailabilityID { get; set; }

        [DisplayName("Start dato")]
        public DateTime StartDate { get; set; }

        [DisplayName("Slut dato")]
        public DateTime EndDate { get; set; }

        [DisplayName("Chauffør status")]
        public bool Status { get; set; }
        public int DriverID { get; set; }
        public Driver Driver { get; set; }

        [NotMapped]
        [DisplayName("Startdato")]
        public string StartDateString => StartDate.ToString("dd-MM-yyyy");
        [NotMapped]
        [DisplayName("Slutdato")]
        public string EndDateString => EndDate.ToString("dd-MM-yyyy");
        [NotMapped]
        [DisplayName("Starttid")]
        public string StartTimeString => StartDate.ToString("HH':'mm");
    }
}
