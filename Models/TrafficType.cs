using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class TrafficType
    {
        [Key]
        public int TypeID { get; set; }
        [DisplayName("Type")]
        [Column(TypeName = "varchar(255)")]
        public string Type { get; set; }
        public List<Traffic> Traffics { get; set; }

    }
}
