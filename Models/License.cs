using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class License
    {
        [Key]
        public int LicenseID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string LicenseName { get; set; }
        public List<DriverLicense> DriverLicenses { get; set; }
    }
}
