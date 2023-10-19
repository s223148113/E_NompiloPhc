using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc.Rendering;


namespace E_NompiloPhc.Controllers.Nutrition
{
    public class MacroNutrientsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public MacroNutrientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return _context.MacroNutrients != null ?
                        View(await _context.MacroNutrients.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MacroNutrients'  is null.");

        }

        public async Task<IActionResult> Details(int? PatientInfoID)
        {

            ViewBag.PatientInfoID = PatientInfoID;
            //if (PatientInfoID == null || _context.MacroNutrients == null)
            //{
            //    return NotFound();
            //}

            var nutrients = await _context.MacroNutrients
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (nutrients == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(nutrients);
        }
        public IActionResult Create(int? PatientInfoID)
        {
            PatientInfoID = ViewBag.PatientInfoID;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PatientInfoID, [Bind("MacroID,Factor,TeriLbw,TeriAbw,TeriCbw,KCal,ChongKg,Cho,Chon,Fat")] MacroNutrients nutrients)
        {

            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                nutrients.PatientInfoID = ViewBag.PatientInfoID;
                _context.Add(nutrients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { nutrients.PatientInfoID });
            }

            return View(nutrients);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MacroNutrients == null)
            {
                return NotFound();
            }

            var nutrients = await _context.MacroNutrients.FindAsync(id);
            if (nutrients == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = nutrients.PatientInfoID;

            return View(nutrients);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MacroID,Factor,TeriLbw,TeriAbw,TeriCbw,KCal,ChongKg,Cho,Chon,Fat")] MacroNutrients nutrients)
        {
            if (id != nutrients.MacroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutrients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MacroNutrientsExists(nutrients.MacroID))
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

            return View(nutrients);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MacroNutrients == null)
            {
                return NotFound();
            }

            var nutrients = await _context.MacroNutrients
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.MacroID == id);
            if (nutrients == null)
            {
                return NotFound();
            }

            return View(nutrients);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MacroNutrients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MacroNutrients'  is null.");
            }
            var nutrients = await _context.MacroNutrients.FindAsync(id);
            if (nutrients != null)
            {
                _context.MacroNutrients.Remove(nutrients);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MacroNutrientsExists(int id)
        {
            return (_context.MacroNutrients?.Any(e => e.MacroID == id)).GetValueOrDefault();
        }
    }
}
