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
    public class RefillDeliveriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefillDeliveriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefillDeliveries
        public async Task<IActionResult> Index()
        {
              return _context.MedicationRefillDelivery != null ? 
                          View(await _context.MedicationRefillDelivery.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MedicationRefillDelivery'  is null.");
        }

        // GET: RefillDeliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationRefillDelivery == null)
            {
                return NotFound();
            }

            var refillDelivery = await _context.MedicationRefillDelivery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refillDelivery == null)
            {
                return NotFound();
            }

            return View(refillDelivery);
        }

        // GET: RefillDeliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefillDeliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientEmail,DeliverName,DeliverLastName,DeliveryDepartment,DepartDate,DeliveryArrival,PHCName,DoctorApprover,DeliverYesNo")] RefillDelivery refillDelivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refillDelivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refillDelivery);
        }

        // GET: RefillDeliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationRefillDelivery == null)
            {
                return NotFound();
            }

            var refillDelivery = await _context.MedicationRefillDelivery.FindAsync(id);
            if (refillDelivery == null)
            {
                return NotFound();
            }
            return View(refillDelivery);
        }

        // POST: RefillDeliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientEmail,DeliverName,DeliverLastName,DeliveryDepartment,DepartDate,DeliveryArrival,PHCName,DoctorApprover,DeliverYesNo")] RefillDelivery refillDelivery)
        {
            if (id != refillDelivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refillDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefillDeliveryExists(refillDelivery.Id))
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
            return View(refillDelivery);
        }

        // GET: RefillDeliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationRefillDelivery == null)
            {
                return NotFound();
            }

            var refillDelivery = await _context.MedicationRefillDelivery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refillDelivery == null)
            {
                return NotFound();
            }

            return View(refillDelivery);
        }

        // POST: RefillDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationRefillDelivery == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicationRefillDelivery'  is null.");
            }
            var refillDelivery = await _context.MedicationRefillDelivery.FindAsync(id);
            if (refillDelivery != null)
            {
                _context.MedicationRefillDelivery.Remove(refillDelivery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefillDeliveryExists(int id)
        {
          return (_context.MedicationRefillDelivery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
