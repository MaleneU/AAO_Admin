using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class StartLocation
    {
        [Key]
        public int StartLocationID { get; set; }

        [DisplayName("Lokation")]
        [Column(TypeName = "varchar(255)")]
        public string Location { get; set; }
        public List<Trip> Trips { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}
