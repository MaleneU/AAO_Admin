using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class LicenseModel
    {
        [Key]
        public int LicenseID { get; set; }
        public string License { get; set; }
    }
}
