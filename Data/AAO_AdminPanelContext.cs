using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AAO_AdminPanel.Models;

namespace AAO_AdminPanel.Data
{
    public class AAO_AdminPanelContext : DbContext
    {
        public AAO_AdminPanelContext (DbContextOptions<AAO_AdminPanelContext> options)
            : base(options)
        {
        }

        public DbSet<AAO_AdminPanel.Models.Trip> TripModel { get; set; }
    }
}
