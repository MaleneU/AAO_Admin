using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Traffic
    {
        [Key]
        public int TrafficID { get; set; }
        public int StartCountryCountryID { get; set; }
        public Country StartCountry { get; set; }
        public int StopCountryCountryID { get; set; }
        public Country StopCountry { get; set; }
        public int TrafficTypeID { get; set; }
        public TrafficType TrafficType { get; set; }


        [NotMapped]
        public string StartAndStop => string.Format("{0} - {1}", StartCountryCountryID, StopCountryCountryID);



    }
}
