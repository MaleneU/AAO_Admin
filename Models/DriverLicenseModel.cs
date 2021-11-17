using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AAO_AdminPanel.Models
{
    public class DriverLicenseModel
    {
        [Key]
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
