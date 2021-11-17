using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AAO_AdminPanel.Models
{
    public class DriverLicenseModel
    {
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public DateTime ExpirationDate { get; set; } // Forkert datatype?
        public string Image { get; set; } // Forkert datatype?
        public sbyte Active { get; set; } // Usikker på datatype
    }
}
