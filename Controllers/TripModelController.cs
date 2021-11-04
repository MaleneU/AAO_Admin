using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_AdminPanel.Data;
using AAO_AdminPanel.Models;

namespace AAO_AdminPanel.Controllers
{
    public class TripModelController : Controller
    {
        private readonly AAO_AdminPanelContext _context;

        public TripModelController(AAO_AdminPanelContext context)
        {
            _context = context;
        }

        // GET: TripModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripModel.ToListAsync());
        }

        // GET: TripModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripModel = await _context.TripModel
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (tripModel == null)
            {
                return NotFound();
            }

            return View(tripModel);
        }

        // GET: TripModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID,StartDateAndTime,StopDate,Duration,ContactID,DescriptionOfTrip,TrafficID,DepartmentID,StatusID,TypeID")] TripModel tripModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripModel);
        }

        // GET: TripModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripModel = await _context.TripModel.FindAsync(id);
            if (tripModel == null)
            {
                return NotFound();
            }
            return View(tripModel);
        }

        // POST: TripModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,StartDateAndTime,StopDate,Duration,ContactID,DescriptionOfTrip,TrafficID,DepartmentID,StatusID,TypeID")] TripModel tripModel)
        {
            if (id != tripModel.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripModelExists(tripModel.TripID))
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
            return View(tripModel);
        }

        // GET: TripModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripModel = await _context.TripModel
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (tripModel == null)
            {
                return NotFound();
            }

            return View(tripModel);
        }

        // POST: TripModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripModel = await _context.TripModel.FindAsync(id);
            _context.TripModel.Remove(tripModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripModelExists(int id)
        {
            return _context.TripModel.Any(e => e.TripID == id);
        }
    }
}
