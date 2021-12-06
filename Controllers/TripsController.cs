using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_AdminPanel.Data;
using AAO_AdminPanel.Models;
using Microsoft.AspNetCore.Authorization;
using AAO_AdminPanel.Utilities;

namespace AAO_AdminPanel.Controllers
{
    // [Authorize] // Log in needed
    public class TripsController : Controller
    {
        private readonly MySQLDbContext _context;

        public TripsController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index(int? StartLocationID, int? DepartmentID, int? page, int? pageSizeID,
            string actionButton, string sortDirection = "asc", string sortField = "Startdato")
        {
            string[] sortOptions = new[] { "Startdato", "Slutdato", "Trafik", "Varighed", "Afdeling" };
            PopulateDropDownLists();
            var trips = from t in _context.Trip
                        .Include(t => t.Department)
                        .Include(t => t.Startlocation)
                        .Include(t => t.Traffic)
                        .ThenInclude(t => t.TrafficType)
                        .Include(t => t.User)
                        .Include(t => t.Traffic.StartCountry)
                        .Include(t => t.Traffic.StopCountry)
                        .Include(t => t.Requests).ThenInclude(t => t.Status)
                         select t;

            // Filter: StartLocation
            if (StartLocationID.HasValue)
            {
                trips = trips.Where(t => t.StartLocationID == StartLocationID);
            }
            // Filter: Department
            if (DepartmentID.HasValue)
            {
                trips = trips.Where(t => t.DepartmentID == DepartmentID);
            }

            // If filtering or sorting 
            if (!String.IsNullOrEmpty(actionButton))
            {
                page = 1; // Reset page

                if (sortOptions.Contains(actionButton)) // Change sorting request
                {
                    if (actionButton == sortField) // Reverse order on field
                    { 
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                }
                sortField = actionButton; // Sort by button clicked
            }

            if (sortField == "Startdato")
            {
                if (sortDirection == "asc")
                {
                    trips = trips.OrderBy(t => t.StartDateAndTime);
                }
                else
                {
                    trips = trips.OrderByDescending(t => t.StartDateAndTime);
                }
            }
            else if (sortField == "Slutdato")
            {
                if (sortDirection == "asc")
                {
                    trips = trips.OrderByDescending(t => t.StopDate);
                }
                else
                {
                    trips = trips.OrderBy(t => t.StopDate);
                }
            }
            else if (sortField == "Trafik")
            {
                if (sortDirection == "asc")
                {
                    trips = trips.OrderBy(t => t.Traffic);
                }
                else
                {
                    trips = trips.OrderByDescending(t => t.Traffic);
                }
            }
            else if (sortField == "Varighed")
            {
                if (sortDirection == "asc")
                {
                    trips = trips.OrderBy(t => t.Duration);
                }
                else
                {
                    trips = trips.OrderByDescending(t => t.Duration);
                }
            }
            else if (sortField == "Afdeling")
            {
                if (sortDirection == "asc")
                {
                    trips = trips.OrderBy(t => t.Department);
                }
                else
                {
                    trips = trips.OrderByDescending(t => t.Department);
                }
            }

            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;
            ViewData["RequestsWithDriver"] = _context.Request.Where(m => m.StatusID == 1);

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
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Department)
                .Include(t => t.Startlocation)
                .Include(t => t.Traffic)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }


        // GET: Trips/Create
        public IActionResult Create()
        {

            ViewData["StartAndStopCountries"] = _context.Traffic.Include(t => t.StartCountry).Include(t => t.StopCountry);

            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name");
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "Location");
            ViewData["StartAndStop"] = new SelectList(_context.Traffic, "TrafficID", "StartAndStop");
            ViewData["UserID"] = new SelectList(_context.User.Where(r => r.RoleID == 2), "UserID", "Fullname");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID, StartDateAndTime, StopDate,Duration,UserID,Description,TrafficID,DepartmentID,StartLocationID,Urgent")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "Name", trip.DepartmentID);
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID", trip.StartLocationID);
            ViewData["TrafficID"] = new SelectList(_context.Traffic, "TrafficID", "StartCountryCountryID", trip.TrafficID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", trip.UserID);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID", trip.DepartmentID);
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID", trip.StartLocationID);
            ViewData["TrafficID"] = new SelectList(_context.Traffic, "TrafficID", "TrafficID", trip.TrafficID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", trip.UserID);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,StartDateAndTime,StopDate,Duration,UserID,Description,TrafficID,DepartmentID,StartLocationID,Urgent")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID", trip.DepartmentID);
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID", trip.StartLocationID);
            ViewData["TrafficID"] = new SelectList(_context.Traffic, "TrafficID", "TrafficID", trip.TrafficID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", trip.UserID);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Department)
                .Include(t => t.Startlocation)
                .Include(t => t.Traffic)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trip.FindAsync(id);
            _context.Trip.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.TripID == id);
        }

        //public async Task<IActionResult> RemoveDriver(int? id)
        //{

        //    //var test = _context.

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var trip = await _context.Trip
        //        .Include(t => t.Department)
        //        .Include(t => t.Startlocation)
        //        .Include(t => t.Traffic)
        //        .Include(t => t.User)
        //        .Include(t => t.Requests).ThenInclude(t => t.Status)
        //        .Include(t => t.Requests).ThenInclude(t => t.Driver).ThenInclude(t => t.User)

        //        .FirstOrDefaultAsync(m => m.TripID == id);
        //    if (trip == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Sat"] = _context.User.Where(r => r.RoleID == id);
        //    return View(trip);
        //}

        public async Task<IActionResult> RemoveDriver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var requests = _context.Request
                        .Include(r => r.Driver).ThenInclude(r => r.User)
                        .Include(r => r.Driver).ThenInclude(r => r.DriverLicenses).ThenInclude(r => r.License)
                        .Include(r => r.Trip)
                        .Include(r => r.Status)
                        .Where(m => m.TripID == id).Where(m => m.StatusID == 1)
                        ;
                        
            if (requests == null)
            {
                return NotFound();
            }

            return View(await requests.ToListAsync());
        }
        [HttpPost]
        public ActionResult RemoveConfirmed(Microsoft.AspNetCore.Http.IFormCollection formCollection)
        {
            string[] ids = formCollection["RequestID"];
            foreach (var id in ids)
            {

                var request = this._context.Request.Find(int.Parse(id));
                _context.Request.Remove(request);
                _context.SaveChanges();
                
            }
            return RedirectToAction("Index");

        }
    }
}
