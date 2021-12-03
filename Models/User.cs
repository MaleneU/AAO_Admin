using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        [DisplayName("Brugernavn")]
        [Column(TypeName = "varchar(45)")]
        public string Username { get; set; }

        [Column(TypeName = "varchar(64)")]
        [DisplayName("Kodeord")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Fornavn")]
        public string Firstname { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Efternavn")]
        public string Lastname { get; set; }
        
        [DisplayName("Email adresse")]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [DisplayName("Tlf. Nr.")]
        public int Phone { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
      
        public List<Address> Addresses  { get; set; }
        public List<Trip> Trips { get; set; }
        
        public Driver Driver { get; set; }

        [NotMapped]

        [DisplayName("Navn")]
        public string Fullname => string.Format("{0} {1}", Firstname, Lastname);

    }
}
