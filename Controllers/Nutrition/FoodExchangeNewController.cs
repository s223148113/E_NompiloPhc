using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.Nutrition
{
    public class FoodExchangeNewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodExchangeNewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodExchangeNew
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoodExchange.Include(f => f.PatientInfo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FoodExchangeNew/Details/5
        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _context.FoodExchange == null)
            {
                return NotFound();
            }

            var foodExchange = await _context.FoodExchange
                .Include(f => f.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (foodExchange == null)
            {
                return NotFound();
            }

            return View(foodExchange);
        }

        // GET: FoodExchangeNew/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewData["PatientInfoID"] = PatientInfoID;
            return View();
        }

        // POST: FoodExchangeNew/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PatientInfoID, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange foodExchange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodExchange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientInfoID"] = PatientInfoID;
            PatientInfoID = foodExchange.PatientInfoID;
            return View(foodExchange);
        }

        // GET: FoodExchangeNew/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodExchange == null)
            {
                return NotFound();
            }

            var foodExchange = await _context.FoodExchange.FindAsync(id);
            if (foodExchange == null)
            {
                return NotFound();
            }
            ViewData["PatientInfoID"] = foodExchange.PatientInfoID;
            return View(foodExchange);
        }

        // POST: FoodExchangeNew/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange foodExchange)
        {
            if (id != foodExchange.FoodExchangeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodExchange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExchangeExists(foodExchange.FoodExchangeID))
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
            ViewData["PatientInfoID"] = foodExchange.PatientInfoID;
            return View(foodExchange);
        }

        // GET: FoodExchangeNew/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodExchange == null)
            {
                return NotFound();
            }

            var foodExchange = await _context.FoodExchange
                .Include(f => f.PatientInfo)
                .FirstOrDefaultAsync(m => m.FoodExchangeID == id);
            if (foodExchange == null)
            {
                return NotFound();
            }

            return View(foodExchange);
        }

        // POST: FoodExchangeNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodExchange == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FoodExchange'  is null.");
            }
            var foodExchange = await _context.FoodExchange.FindAsync(id);
            if (foodExchange != null)
            {
                _context.FoodExchange.Remove(foodExchange);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExchangeExists(int id)
        {
            return (_context.FoodExchange?.Any(e => e.FoodExchangeID == id)).GetValueOrDefault();
        }
    }
}
