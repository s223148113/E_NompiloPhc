using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.GBV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.GBV
{
    public class MedicationRefillDeliveriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationRefillDeliveriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicationRefillDeliveries
        public async Task<IActionResult> Index()
        {
            return _context.MedicationRefillDelivery != null ?
                        View(await _context.MedicationRefillDelivery.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MedicationRefillDelivery'  is null.");
        }

        // GET: MedicationRefillDeliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationRefillDelivery == null)
            {
                return NotFound();
            }

            var medicationRefillDelivery = await _context.MedicationRefillDelivery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicationRefillDelivery == null)
            {
                return NotFound();
            }

            return View(medicationRefillDelivery);
        }

        // GET: MedicationRefillDeliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicationRefillDeliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RefillDelivery medicationRefillDelivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationRefillDelivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicationRefillDelivery);
        }

        // GET: MedicationRefillDeliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationRefillDelivery == null)
            {
                return NotFound();
            }

            var medicationRefillDelivery = await _context.MedicationRefillDelivery.FindAsync(id);
            if (medicationRefillDelivery == null)
            {
                return NotFound();
            }
            return View(medicationRefillDelivery);
        }

        // POST: MedicationRefillDeliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RefillDelivery medicationRefillDelivery)
        {
            if (id != medicationRefillDelivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationRefillDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationRefillDeliveryExists(medicationRefillDelivery.Id))
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
            return View(medicationRefillDelivery);
        }

        // GET: MedicationRefillDeliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationRefillDelivery == null)
            {
                return NotFound();
            }

            var medicationRefillDelivery = await _context.MedicationRefillDelivery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicationRefillDelivery == null)
            {
                return NotFound();
            }

            return View(medicationRefillDelivery);
        }

        // POST: MedicationRefillDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationRefillDelivery == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicationRefillDelivery'  is null.");
            }
            var medicationRefillDelivery = await _context.MedicationRefillDelivery.FindAsync(id);
            if (medicationRefillDelivery != null)
            {
                _context.MedicationRefillDelivery.Remove(medicationRefillDelivery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationRefillDeliveryExists(int id)
        {
            return (_context.MedicationRefillDelivery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
