using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public List<UserModel> UserID { get; set; } = new List<UserModel>();
    }
}
