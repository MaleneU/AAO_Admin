using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Username { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Firstname { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Lastname { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        public int Phone { get; set; }
        public Department Department { get; set; }

        public Role Role { get; set; }
      
        public List<Address> Addresses  { get; set; }
        public List<Trip> Trips { get; set; }
        public Driver Driver { get; set; }


    }
}
