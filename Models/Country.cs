using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CountryName { get; set; }

        public int CityID { get; set; }

    }
}
