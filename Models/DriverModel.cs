using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class DriverModel
    {
        [Key]
        public int DriverID { get; set; }
        public int UserID { get; set; }
        public bool Active { get; set; }
        public int StartLocationID { get; set; }
        public int TypeID { get; set; }
    }
}
