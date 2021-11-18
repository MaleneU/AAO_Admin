using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Username { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Firstname { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Lastname { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        public int Phone { get; set; }

        public int AddressID { get; set; }

        public int DepartmentID { get; set; }

        public int RoleID { get; set; }



        //public List<RoleModel> Roles  { get; set; }
        //public List<AddressModel> Addresses  { get; set; }
        //public List<DepartmentModel> departments  { get; set; }
    }
}
