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

namespace AAO_AdminPanel.Controllers
{
    [Authorize] // Log in needed
    public class TripsController : Controller
    {
        private readonly MySQLDbContext _context;

        public TripsController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index(int? StartLocationID, int? DepartmentID)
        {
            PopulateDropDownLists();
            var trips = (from t in _context.Trip
                        .Include(t => t.Department)
                        .Include(t => t.StartLocation)
                        .Include(t => t.Traffic)
                        .Include(t => t.User)
                        .Include(t => t.Traffic.StartCountry)
                        .Include(t => t.Traffic.StopCountry)
                        .Include(t => t.Requests).ThenInclude(t => t.Status)
                         select t)
                        .AsNoTracking();

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
            // Filter: If trip has Requests with Status 1
            //if (StatusID.Value == 1)
            //{
            //    trips = trips.Where(t => t.Requests);
            //}

            return View(await trips.ToListAsync());
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
                .Include(t => t.StartLocation)
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
        public async Task<IActionResult> Create([Bind("TripID,StartDateAndTime,StopDate,Duration,UserID,Description,TrafficID,DepartmentID,StartLocationID,Urgent")] Trip trip)
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
                .Include(t => t.StartLocation)
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
    }
}
