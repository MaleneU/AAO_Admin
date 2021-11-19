using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class TrafficType
    {
        [Key]
        public int TypeID { get; set; }
        public string Type { get; set; }
    }
}
