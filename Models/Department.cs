using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
       
        [DisplayName("Navn på afdeling")]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public List<User> UserID { get; set; }
        public List<Trip> Trips { get; set; }

    }
}
