﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class License
    {
        [Key]
        public int LicenseID { get; set; }
        public string LicenseName { get; set; }
    }
}
