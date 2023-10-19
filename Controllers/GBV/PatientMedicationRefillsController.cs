using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.GBV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.GBV
{
    public class PatientMedicationRefillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientMedicationRefillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientMedicationRefills
        public async Task<IActionResult> Index()
        {
            return _context.PatientMedicationRefill != null ?
                        View(await _context.PatientMedicationRefill.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.PatientMedicationRefill'  is null.");
        }

        // GET: PatientMedicationRefills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientMedicationRefill == null)
            {
                return NotFound();
            }

            var patientMedicationRefill = await _context.PatientMedicationRefill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientMedicationRefill == null)
            {
                return NotFound();
            }

            return View(patientMedicationRefill);
        }

        // GET: PatientMedicationRefills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientMedicationRefills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,MedicationName,ImprintCode,Colour,Shape,AssignedDoctor,Date")] PatientMedicationRefill patientMedicationRefill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientMedicationRefill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientMedicationRefill);
        }

        // GET: PatientMedicationRefills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientMedicationRefill == null)
            {
                return NotFound();
            }

            var patientMedicationRefill = await _context.PatientMedicationRefill.FindAsync(id);
            if (patientMedicationRefill == null)
            {
                return NotFound();
            }
            return View(patientMedicationRefill);
        }

        // POST: PatientMedicationRefills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,MedicationName,ImprintCode,Colour,Shape,AssignedDoctor,Date")] PatientMedicationRefill patientMedicationRefill)
        {
            if (id != patientMedicationRefill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientMedicationRefill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientMedicationRefillExists(patientMedicationRefill.Id))
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
            return View(patientMedicationRefill);
        }

        // GET: PatientMedicationRefills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientMedicationRefill == null)
            {
                return NotFound();
            }

            var patientMedicationRefill = await _context.PatientMedicationRefill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientMedicationRefill == null)
            {
                return NotFound();
            }

            return View(patientMedicationRefill);
        }

        // POST: PatientMedicationRefills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientMedicationRefill == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PatientMedicationRefill'  is null.");
            }
            var patientMedicationRefill = await _context.PatientMedicationRefill.FindAsync(id);
            if (patientMedicationRefill != null)
            {
                _context.PatientMedicationRefill.Remove(patientMedicationRefill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientMedicationRefillExists(int id)
        {
            return (_context.PatientMedicationRefill?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
