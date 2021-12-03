using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        [DisplayName("Status navn")]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public List<Request> Requests { get; set; }
    }
}
