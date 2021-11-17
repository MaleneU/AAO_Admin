using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class TrafficModel
    {
        public int TrafficID { get; set; }
        public int StartCountryID { get; set; }
        public int StopCountryID { get; set; }
        public int TypeID { get; set; }
    }
}
