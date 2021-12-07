using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DisplayName("Aktiv")]
        public bool Active { get; set; }
        public int StartLocationID { get; set; }
        public StartLocation StartLocation { get; set; }
        public int TrafficTypeID { get; set; }
        public TrafficType TrafficType { get; set; }

        public List<DriverLicense> DriverLicenses { get; set; }
        public List<Availability> Availabilities { get; set; }
    }
}
