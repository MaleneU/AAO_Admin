using AAO_AdminPanel.Data;
using AAO_AdminPanel.Models;
using AAO_AdminPanel.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Controllers
{
    public class DriversController : Controller
    {
        private readonly MySQLDbContext _context;

        public DriversController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index(int? page, int? pageSizeID)
        {
            var drivers = from d in _context.Driver
                .Include(d => d.StartLocation)
                .Include(d => d.TrafficType)
                .Include(d => d.User)
                .Include(d => d.DriverLicenses).ThenInclude(d => d.License)
                .Include(d => d.Availabilities)
                          select d;

            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<Driver>.CreateAsync(drivers.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
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

        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID");
            ViewData["TrafficTypeID"] = new SelectList(_context.Type, "TypeID", "TypeID");
            ViewData["DriverUsers"] = _context.User.Where(r => r.RoleID == 3);
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverID,UserID,Active,StartLocationID,TrafficTypeID")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID", driver.StartLocationID);
            ViewData["TrafficTypeID"] = new SelectList(_context.Type, "TypeID", "TypeID", driver.TrafficTypeID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", driver.UserID);
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID", driver.StartLocationID);
            ViewData["TrafficTypeID"] = new SelectList(_context.Type, "TypeID", "TypeID", driver.TrafficTypeID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", driver.UserID);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverID,UserID,Active,StartLocationID,TrafficTypeID")] Driver driver)
        {
            if (id != driver.DriverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.DriverID))
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
            ViewData["StartLocationID"] = new SelectList(_context.StartLocation, "StartLocationID", "StartLocationID", driver.StartLocationID);
            ViewData["TrafficTypeID"] = new SelectList(_context.Type, "TypeID", "TypeID", driver.TrafficTypeID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", driver.UserID);
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


        // POST Add Driver To Trip
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
