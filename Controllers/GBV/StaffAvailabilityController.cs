using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.GBV;

namespace E_NompiloPhc.Controllers.GBV
{
    public class StaffAvailabilityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffAvailabilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffAvailability
        public async Task<IActionResult> Index()
        {
              return _context.StaffLogTime != null ? 
                          View(await _context.StaffLogTime.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StaffLogTime'  is null.");
        }

        // GET: StaffAvailability/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StaffLogTime == null)
            {
                return NotFound();
            }

            var staffLogTime = await _context.StaffLogTime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffLogTime == null)
            {
                return NotFound();
            }

            return View(staffLogTime);
        }

        // GET: StaffAvailability/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffAvailability/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Department,Vacation,Sick,Regular,Start,End")] StaffLogTime staffLogTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffLogTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffLogTime);
        }

        // GET: StaffAvailability/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StaffLogTime == null)
            {
                return NotFound();
            }

            var staffLogTime = await _context.StaffLogTime.FindAsync(id);
            if (staffLogTime == null)
            {
                return NotFound();
            }
            return View(staffLogTime);
        }

        // POST: StaffAvailability/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Department,Vacation,Sick,Regular,Start,End")] StaffLogTime staffLogTime)
        {
            if (id != staffLogTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffLogTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffLogTimeExists(staffLogTime.Id))
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
            return View(staffLogTime);
        }

        // GET: StaffAvailability/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StaffLogTime == null)
            {
                return NotFound();
            }

            var staffLogTime = await _context.StaffLogTime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffLogTime == null)
            {
                return NotFound();
            }

            return View(staffLogTime);
        }

        // POST: StaffAvailability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StaffLogTime == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StaffLogTime'  is null.");
            }
            var staffLogTime = await _context.StaffLogTime.FindAsync(id);
            if (staffLogTime != null)
            {
                _context.StaffLogTime.Remove(staffLogTime);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffLogTimeExists(int id)
        {
          return (_context.StaffLogTime?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
