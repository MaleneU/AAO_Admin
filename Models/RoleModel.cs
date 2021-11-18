using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class RoleModel
    {
        public int RoleID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

    }
}
