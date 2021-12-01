using AAO_AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.ViewModels
{
    public class TripViewModel
    {
        //public List<Trip> Trips { get; set; }
        //public List<User> Users { get; set; }
       // public List<Traffic> Traffics { get; set; }
       // public List<Department> Departments { get; set; }

        public IEnumerable<TripModel> Trips { get; set; }
    }
}
