using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.GBV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.GBV
{
    public class CheckUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckUps
        public async Task<IActionResult> Index()
        {
            return _context.CheckUp != null ?
                        View(await _context.CheckUp.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.CheckUp'  is null.");
        }

        // GET: CheckUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CheckUp == null)
            {
                return NotFound();
            }

            var checkUp = await _context.CheckUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkUp == null)
            {
                return NotFound();
            }

            return View(checkUp);
        }

        // GET: CheckUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientName,PatientLastName,PatientFirstName,BodyTemperature,OxygenLevel,PulseRate,Weight,BloodPressure,Diagnosis,Therapy,AssignedMedication,CheckUpNurse,AssignedDoctor,Date")] CheckUp checkUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkUp);
        }

        // GET: CheckUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CheckUp == null)
            {
                return NotFound();
            }

            var checkUp = await _context.CheckUp.FindAsync(id);
            if (checkUp == null)
            {
                return NotFound();
            }
            return View(checkUp);
        }

        // POST: CheckUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientName,PatientLastName,PatientFirstName,BodyTemperature,OxygenLevel,PulseRate,Weight,BloodPressure,Diagnosis,Therapy,AssignedMedication,CheckUpNurse,AssignedDoctor,Date")] CheckUp checkUp)
        {
            if (id != checkUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckUpExists(checkUp.Id))
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
            return View(checkUp);
        }

        // GET: CheckUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CheckUp == null)
            {
                return NotFound();
            }

            var checkUp = await _context.CheckUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkUp == null)
            {
                return NotFound();
            }

            return View(checkUp);
        }

        // POST: CheckUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CheckUp == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CheckUp'  is null.");
            }
            var checkUp = await _context.CheckUp.FindAsync(id);
            if (checkUp != null)
            {
                _context.CheckUp.Remove(checkUp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckUpExists(int id)
        {
            return (_context.CheckUp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
