// Not used in the webapp. Just for creating mock data. 

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
    [Authorize] // Log in required
    public class RequestsController : Controller
    {
        private readonly MySQLDbContext _context;

        public RequestsController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var requests = (from r in _context.Request
                        .Include(r => r.Driver).ThenInclude(r => r.User)
                        .Include(r => r.Trip)
                        .Include(r => r.Status)
                         select r)
                        .AsNoTracking();

            return View(await requests.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                var requests = await (from r in _context.Request
                        .Include(r => r.Driver)
                        .Include(r => r.Trip)
                        .Include(r => r.Status)
                                select r)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (requests == null)
            {
                return NotFound();
            }

            return View(requests);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["TripID"] = new SelectList(_context.Trip, "TripID", "TripID");
            ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "DriverID");
            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "Name");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,TripID,DriverID,StatusID")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TripID"] = new SelectList(_context.Trip, "TripID", "TripID", request.TripID);
            ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "DriverID", request.DriverID);
            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusID", request.StatusID);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["TripID"] = new SelectList(_context.Trip, "TripID", "TripID", request.TripID);
            ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "DriverID", request.DriverID);
            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusID", request.StatusID);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,TripID,DriverID,StatusID")] Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
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
            ViewData["TripID"] = new SelectList(_context.Trip, "TripID", "TripID", request.TripID);
            ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "DriverID", request.DriverID);
            ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusID", request.StatusID);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var requests = await _context.Request
                        .Include(r => r.Driver)
                        .Include(r => r.Trip)
                        .Include(r => r.Status)
                        .FirstOrDefaultAsync(m => m.RequestID == id);
            if (requests == null)
            {
                return NotFound();
            }

            return View(requests);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Request.FindAsync(id);
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.RequestID == id);
        }
    }
}
