using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Request
    {
        [Key]
        [Display(Name = "Anmodninger")]
        public int RequestID { get; set; }
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
        public int TripID { get; set; }
        public Trip Trip { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public bool StatusBool
        {
            get {
                bool statusBool = false;
                if (StatusID == 1) { statusBool = true; }
                return statusBool; }
            set { StatusID = value ? 1 : 0; }

        }
    }
}
