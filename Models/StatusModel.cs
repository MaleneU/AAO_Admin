using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class StatusModel
    {
        [Key]
        public int StatusID { get; set; }
        public string Name { get; set; }
    }
}
