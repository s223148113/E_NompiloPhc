using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.GBV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.GBV
{
    public class PHCMedicationRefillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PHCMedicationRefillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PHCMedicationRefills
        public async Task<IActionResult> Index()
        {
            return _context.PHCMedicationRefill != null ?
                        View(await _context.PHCMedicationRefill.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.PHCMedicationRefill'  is null.");
        }

        // GET: PHCMedicationRefills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PHCMedicationRefill == null)
            {
                return NotFound();
            }

            var pHCMedicationRefill = await _context.PHCMedicationRefill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pHCMedicationRefill == null)
            {
                return NotFound();
            }

            return View(pHCMedicationRefill);
        }

        // GET: PHCMedicationRefills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PHCMedicationRefills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PharmacistName,PharmacistLastName,Email,Phone,MedicationName,ImprintCode,Colour,Shape,Department,MedicationSupplier,Date")] PHCMedicationRefill pHCMedicationRefill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pHCMedicationRefill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pHCMedicationRefill);
        }

        // GET: PHCMedicationRefills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PHCMedicationRefill == null)
            {
                return NotFound();
            }

            var pHCMedicationRefill = await _context.PHCMedicationRefill.FindAsync(id);
            if (pHCMedicationRefill == null)
            {
                return NotFound();
            }
            return View(pHCMedicationRefill);
        }

        // POST: PHCMedicationRefills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PharmacistName,PharmacistLastName,Email,Phone,MedicationName,ImprintCode,Colour,Shape,Department,MedicationSupplier,Date")] PHCMedicationRefill pHCMedicationRefill)
        {
            if (id != pHCMedicationRefill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pHCMedicationRefill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PHCMedicationRefillExists(pHCMedicationRefill.Id))
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
            return View(pHCMedicationRefill);
        }

        // GET: PHCMedicationRefills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PHCMedicationRefill == null)
            {
                return NotFound();
            }

            var pHCMedicationRefill = await _context.PHCMedicationRefill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pHCMedicationRefill == null)
            {
                return NotFound();
            }

            return View(pHCMedicationRefill);
        }

        // POST: PHCMedicationRefills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PHCMedicationRefill == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PHCMedicationRefill'  is null.");
            }
            var pHCMedicationRefill = await _context.PHCMedicationRefill.FindAsync(id);
            if (pHCMedicationRefill != null)
            {
                _context.PHCMedicationRefill.Remove(pHCMedicationRefill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PHCMedicationRefillExists(int id)
        {
            return (_context.PHCMedicationRefill?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
