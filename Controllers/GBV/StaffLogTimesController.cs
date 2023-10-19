using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.GBV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.GBV
{
    public class StaffLogTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffLogTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffLogTimes
        public async Task<IActionResult> Index()
        {
            return _context.StaffLogTime != null ?
                        View(await _context.StaffLogTime.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.StaffLogTime'  is null.");
        }

        // GET: StaffLogTimes/Details/5
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

        // GET: StaffLogTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffLogTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] StaffLogTime staffLogTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffLogTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffLogTime);
        }

        // GET: StaffLogTimes/Edit/5
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

        // POST: StaffLogTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] StaffLogTime staffLogTime)
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

        // GET: StaffLogTimes/Delete/5
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

        // POST: StaffLogTimes/Delete/5
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
