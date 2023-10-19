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
    public class UserAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserAppointments
        public async Task<IActionResult> Index()
        {
              return _context.VirtualAppointment != null ? 
                          View(await _context.VirtualAppointment.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.VirtualAppointment'  is null.");
        }

        // GET: UserAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VirtualAppointment == null)
            {
                return NotFound();
            }

            var userAppointment = await _context.VirtualAppointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAppointment == null)
            {
                return NotFound();
            }

            return View(userAppointment);
        }

        // GET: UserAppointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ReasonForVisit,Consulatation,Email,PhoneNumber,Time")] UserAppointment userAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAppointment);
        }

        // GET: UserAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VirtualAppointment == null)
            {
                return NotFound();
            }

            var userAppointment = await _context.VirtualAppointment.FindAsync(id);
            if (userAppointment == null)
            {
                return NotFound();
            }
            return View(userAppointment);
        }

        // POST: UserAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ReasonForVisit,Consulatation,Email,PhoneNumber,Time")] UserAppointment userAppointment)
        {
            if (id != userAppointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAppointmentExists(userAppointment.Id))
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
            return View(userAppointment);
        }

        // GET: UserAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VirtualAppointment == null)
            {
                return NotFound();
            }

            var userAppointment = await _context.VirtualAppointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAppointment == null)
            {
                return NotFound();
            }

            return View(userAppointment);
        }

        // POST: UserAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VirtualAppointment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VirtualAppointment'  is null.");
            }
            var userAppointment = await _context.VirtualAppointment.FindAsync(id);
            if (userAppointment != null)
            {
                _context.VirtualAppointment.Remove(userAppointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAppointmentExists(int id)
        {
          return (_context.VirtualAppointment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
