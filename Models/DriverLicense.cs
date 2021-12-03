﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int DriverID { get; set; }
        public Driver Driver { get; set; }

        [DisplayName("Udløbs dato")]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Billed")]
        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
