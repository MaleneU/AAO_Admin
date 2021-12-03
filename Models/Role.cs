using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Role
    {
        public int RoleID { get; set; }

        [DisplayName("Rolle")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public List<User> Users  { get; set; }

    }
}
