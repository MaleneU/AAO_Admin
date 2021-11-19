using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class StartLocation
    {
        [Key]
        public int StartLocationID { get; set; }
        public string Location { get; set; }
    }
}
