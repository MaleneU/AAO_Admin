using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public Driver Driver { get; set; }
        public Trip Trip { get; set; }
        public Status Status { get; set; }
    }
}
