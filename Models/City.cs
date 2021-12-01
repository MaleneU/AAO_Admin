using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CityName { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string ZipCode { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }

        public List<Address> Addresses  { get; set; }
    }
}

