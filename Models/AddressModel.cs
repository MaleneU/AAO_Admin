using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class AddressModel
    {
        [Key]
        public int AddressID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        public int CityID { get; set; }

        //public List<UserModel> Users { get; set; }
    }
}
