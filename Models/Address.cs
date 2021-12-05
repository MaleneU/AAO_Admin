using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }



        [Column(TypeName = "varchar(255)")]

        [DisplayName("Adresse ")]
        public string AddressLine { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
