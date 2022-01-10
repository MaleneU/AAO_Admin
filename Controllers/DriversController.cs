using AAO_AdminPanel.Data;
using AAO_AdminPanel.Models;
using AAO_AdminPanel.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Controllers
{
    /*[Authorize]*/ // Log in required
    public class DriversController : Controller
    {
        private readonly MySQLDbContext _context;

        public DriversController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index(int? LicenseID, int? StartLocationID, int? page, int? pageSizeID,
            string actionButton, string searchString, string sortDirection = "asc", string sortField = "Navn")
        {

            string[] sortOptions = new[] { "Navn", "Phone", "Email", "License" };
            PopulateDropDownLists();

            var drivers = from d in _context.Driver
                .Include(d => d.StartLocation)
                .Include(d => d.TrafficType)
                .Include(d => d.User)
                .Include(d => d.DriverLicenses).ThenInclude(d => d.License)
                .Include(d => d.Availabilities)
                          select d;
           
            // Filter: StartLacation 
            if (StartLocationID.HasValue)
            {
                drivers = drivers.Where(t => t.StartLocationID == StartLocationID);
            }


            // Filter: DriverLocation
            if (LicenseID.HasValue)
            {
                drivers = drivers.Where(t => t.DriverLicenses.Any(t => t.LicenseID == LicenseID));
            }
      

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

            // Sorting
            if (sortField == "Navn")
            {
                if (sortDirection == "asc")
                {
                    drivers = drivers.OrderBy(t => t.User.Firstname)
                                     .ThenBy(t => t.User.Lastname);
                }
                else
                {
                    drivers = drivers.OrderByDescending(t => t.User.Firstname)
                                     .ThenByDescending(t => t.User.Lastname);
                }
            }
            else if (sortField == "Phone")
            {
                if (sortDirection == "asc")
                {
                    drivers = drivers.OrderBy(t => t.User.Phone);
                }
                else
                {
                    drivers = drivers.OrderByDescending(t => t.User.Phone);
                }
            }
            else if (sortField == "Email")
            {
                if (sortDirection == "asc")
                {
                    drivers = drivers.OrderBy(t => t.User.Email);
                }
                else
                {
                    drivers = drivers.OrderByDescending(t => t.User.Email);
                }
            }

            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;


            ViewData["DriversSearchBar"] = searchString;

            
            //Search bar
            if (!String.IsNullOrEmpty(searchString))
            {
                drivers = drivers.Where(d => d.User.Firstname.Contains(searchString) || d.User.Lastname.Contains(searchString) || d.User.Email.Contains(searchString));
            }

            // Page size
            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);


            var pagedData = await PaginatedList<Driver>.CreateAsync(drivers.AsNoTracking(), page ?? 1, pageSize);

            



            return View(pagedData);
        }

        private void PopulateDropDownLists(Driver driver = null)
        {
            var startLocationQuery = from l in _context.StartLocation
                                orderby l.StartLocationID
                                select l;
            ViewData["StartLocationID"] = new SelectList(startLocationQuery, "StartLocationID", "Location", driver?.StartLocationID);
           
            var licenseQuery = from s in _context.License
                              orderby s.LicenseID
                              select s;
            ViewData["LicenseID"] = new SelectList(licenseQuery, "LicenseID", "LicenseName", driver?.DriverLicenses);
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .Include(d => d.StartLocation)
                .Include(d => d.TrafficType)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DriverID == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

      

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .Include(d => d.StartLocation)
                .Include(d => d.TrafficType)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DriverID == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Driver.FindAsync(id);
            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Driver.Any(e => e.DriverID == id);
        }

        public async Task<IActionResult> DriverActivation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .Include(d => d.StartLocation)
                .Include(d => d.TrafficType)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DriverID == id);
            if (driver == null)
            {
                return NotFound();
            }
            if (driver.Active == true)
            {
                driver.Active = false;
            }
            else if (driver.Active == false)
            {
                driver.Active = true;
            }

            _context.Driver.Update(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


        // GET Add Driver To Trip
        public IActionResult AddTripToDriver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["DriverID"] = id;
            var availabilities = _context.Availability.Where(a => a.DriverID == id).ToList();
            var trips = _context.Trip.Include(t => t.Requests).ThenInclude(t => t.Driver).ToList(); ;

            var availableTrips = new List<Trip>();

            foreach (var a in availabilities)
            {
                foreach (var t in trips)
                {
                    if (t.StartDateAndTime >= a.StartDate && t.StopDate <= a.EndDate && t.HasDriver == false)
                    {
                        availableTrips.Add(t);

                    }
                }
            }
            return View(availableTrips);
        }


        // POST Add Trip To Driver
        [HttpPost]
        public async Task<IActionResult> AddTripToDriver(IFormCollection form, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            string[] trips = form["TripID"];
            foreach (var t in trips)
            {
                int driverId = id.Value;
                var request = new Request
                {
                    TripID = int.Parse(t),
                    DriverID = driverId,
                    StatusID = 1

                };
                _context.Add(request);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: Create Availability
        public IActionResult CreateAvailability(int? id)
        {
           
            ViewData["DriverID"] = id;
            
            return View();
        }

        // POST: Create Availability      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAvailability([Bind("DriverID, StartDate, EndDate, Status")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(availability);
        }

        // GET: Drivers/EditAvailability/5
        public async Task<IActionResult> EditAvailability(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availability.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
            
            return View(availability);
        }

        // POST: Drivers/EditAvailability/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAvailability(int id, [Bind("AvailabilityID, DriverID, StartDate, EndDate, Status")] Availability availability)
        {
            if (id != availability.AvailabilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailabilityExists(availability.AvailabilityID))
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
            return View(availability);
        }

        // GET: Drivers/DeleteAvailability/5
        public async Task<IActionResult> DeleteAvailability(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var availabilities = await _context.Availability.Include(m => m.Driver).ThenInclude(m => m.User).FirstOrDefaultAsync(m => m.AvailabilityID == id);
            if (availabilities == null)
            {
                return NotFound();
            }

            return View(availabilities);
        }

        // POST: Drivers/DeleteAvailability/5
        [HttpPost, ActionName("DeleteAvailability")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAvailabilityConfirmed(int id)
        {
            var availability = await _context.Availability.FindAsync(id);
            _context.Availability.Remove(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool AvailabilityExists(int id)
        {
            return _context.Availability.Any(e => e.AvailabilityID == id);
        }


    }
}
