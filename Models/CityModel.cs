using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class CityModel
    {
        [Key]
        public int CityID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public  string City { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string ZipCode { get; set; }

        public int CountryID { get; set; }

        //public List<CountryModel> Countries  { get; set; }
    }
}

