using Microsoft.AspNetCore.Mvc;
using System;

using AAO_AdminPanel.Data;
using System.Globalization;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AAO_AdminPanel.Utilities;
using System.Threading.Tasks;
using AAO_AdminPanel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AAO_AdminPanel.Controllers
{
    static class DateTimeExtensions
    {
        static GregorianCalendar _gc = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

      
    }
    public class DashboardController : Controller
    {
        private readonly MySQLDbContext _context;
        

        public DashboardController(MySQLDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(int? StartLocationID, int? DepartmentID, int? TrafficTypeID, int? StatusID, int? page, int? pageSizeID,
               string actionButton, string sortDirection = "asc", string sortField = "Startdato")
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime.Hour < 12 && currentTime.Hour >= 5)
            {
                ViewBag.greeting =" God morgen";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour <= 15)
            {
                ViewBag.greeting = "God eftermiddag";
            }
            else if (currentTime.Hour >= 16 && currentTime.Hour <= 22)
            {
                ViewBag.greeting = "God aften";
            }
            else
            {
                ViewBag.greeting = "God nat";
            }

            DateTime time = DateTime.Today;

           

            ViewBag.weekDay = time.GetWeekOfMonth();

            DateTime dt = DateTime.Now;

            string dayOfWeek = dt.ToString("dddd", new System.Globalization.CultureInfo("da-DA"));
            ViewBag.dayInDanish = dayOfWeek;

            var countTripsToday = _context.Trip.Where(y => y.StartDateAndTime.Date == DateTime.Today.Date)
            .Count();
            ViewBag.countTripsToday = countTripsToday;

            var requestCount = _context.Request.Where(y=> y.Status.Name == "Ikke tildelt").Count();


            ViewBag.requestCount = requestCount;

            int tripWithNoDriverAndRequest = _context.Trip.Where(v => v.Requests.Count == 0).Count();

            ViewBag.tripWithNoDriverAndRequest = tripWithNoDriverAndRequest;


           
            PopulateDropDownLists();


            var trips = from t in _context.Trip.Where(n => n.UserID == 1)
                  .Include(t => t.Department)
                  .Include(t => t.Startlocation)
                  .Include(t => t.Traffic)
                  .ThenInclude(t => t.TrafficType)
                  .Include(t => t.User)
                  .Include(t => t.Traffic.StartCountry)
                  .Include(t => t.Traffic.StopCountry)
                  .Include(t => t.Requests).ThenInclude(t => t.Status)
                  .Include(t => t.Requests).ThenInclude(m => m.Driver).ThenInclude(m => m.User)
                        select t;

            //int days = DateTime.Today.Date.DayOfWeek - DayOfWeek.Sunday;
            //DateTime weekStart = DateTime.Today.Date.AddDays(-days);
            //DateTime weekEnd = weekStart.AddDays(6);


            //var list = from t in _context.Trip.Where(h => h.StartDateAndTime.Date <= weekEnd && h.StopDate >= weekStart)
            //select t;
            //List<int> tripsForTheWeek = new List<int>();


            // Filter: Status "fishstick",
            if (StatusID == 1)
            {
                // Trips = Trips where any requests contain StatusID = 1
                trips = trips.Where(t => t.Requests.Any(t => t.StatusID == 1));
            }

            if (StatusID == 2)
            {
                // Trips = Trips where requests do not contain StatusID = 1
                trips = trips.Where(t => t.Requests.All(t => t.StatusID == 2));
            }


            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;
            ViewData["RequestsWithDriver"] = _context.Request.Where(m => m.StatusID == 1);


            int pageSize = Utilities.PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<Trip>.CreateAsync(trips.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
            
        }

        public async Task<IActionResult> TripsRequestToAccept(int? StartLocationID, int? DepartmentID, int? TrafficTypeID, int? StatusID, int? page, int? pageSizeID,
            string actionButton, string sortDirection = "asc", string sortField = "Startdato")
        {
           
            PopulateDropDownLists();

            var trips = from t in _context.Trip.Where(t => t.Requests.Any(t => t.Status.Name == "Ikke tildelt"))
                 .Include(t => t.Department)
                 .Include(t => t.Startlocation)
                 .Include(t => t.Traffic)
                 .ThenInclude(t => t.TrafficType)
                 .Include(t => t.User)
                 .Include(t => t.Traffic.StartCountry)
                 .Include(t => t.Traffic.StopCountry)
                 .Include(t => t.Requests).ThenInclude(t => t.Status)
                 .Include(t => t.Requests).ThenInclude(m => m.Driver).ThenInclude(m => m.User)
                        select t;



            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<Trip>.CreateAsync(trips.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

       



        private void PopulateDropDownLists(Trip trip = null)
        {
            var locationQuery = from l in _context.StartLocation
                                orderby l.Location
                                select l;
            ViewData["StartLocationID"] = new SelectList(locationQuery, "StartLocationID", "Location", trip?.StartLocationID);
            var departmentQuery = from d in _context.Department
                                  orderby d.Name
                                  select d;
            ViewData["DepartmentID"] = new SelectList(departmentQuery, "DepartmentID", "Name", trip?.DepartmentID);
            var trafficTypeQuery = from t in _context.Type
                                   orderby t.TypeID
                                   select t;
            ViewData["TrafficTypeID"] = new SelectList(trafficTypeQuery, "TypeID", "Type", trip?.Traffic.TrafficTypeID);
            var statusQuery = from s in _context.Status
                              orderby s.StatusID
                              select s;
            ViewData["StatusID"] = new SelectList(statusQuery, "StatusID", "Name", trip?.Requests);
        }


    }
}
