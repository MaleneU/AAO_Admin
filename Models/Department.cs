using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public List<User> UserID { get; set; } = new List<User>();
    }
}
