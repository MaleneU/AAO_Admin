using AAO_AdminPanel.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AAO_AdminPanel.Controllers
{
    public class TripController : Controller
    {
        private readonly MySQLDbContext _db;

        public TripController(MySQLDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //IEnumerable<Trip> objList = _db.Items;
            return View();
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
