using AAO_AdminPanel.Data;
using AAO_AdminPanel.Models;
using AAO_AdminPanel.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    }
}
