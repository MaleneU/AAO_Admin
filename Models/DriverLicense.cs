using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AAO_AdminPanel.Models
{
    public class DriverLicense
    {
        [Key]
        public int DriverLicenseID { get; set; }
        public int LicenseID { get; set; }
        public License License { get; set; }
        public int DriveID { get; set; }
        public Driver Driver { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
