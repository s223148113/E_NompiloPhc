using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.Nutrition
{
    public class DietFoodController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public DietFoodController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IActionResult> Index(int PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
            var dietFood = await _dbcontext.DietFood
                .Where(s => s.PatientInfoID == PatientInfoID)
                .ToListAsync();

            return View(dietFood);
        }

        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.FoodExchange == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = PatientInfoID;
            var DietFood = await _dbcontext.FoodExchange
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (DietFood == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(DietFood);
        }

        // GET: DietFood/Create
        public IActionResult Create(int PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;

            return View();
        }
        // POST: DietFood/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PatientInfoID, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange DietFood)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                DietFood.PatientInfoID = PatientInfoID;
                _dbcontext.Add(DietFood);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { PatientInfoID });
            }
            return View(DietFood);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DietFood = await _dbcontext.FoodExchange.FindAsync(id);
            if (DietFood == null)
            {
                return NotFound();
            }

            return View(DietFood);
        }
        // POST: DietFood/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange DietFood)
        {
            if (id != DietFood.FoodExchangeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(DietFood);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietFoodExists(DietFood.FoodExchangeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { DietFood.PatientInfoID });
            }
            return View(DietFood);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DietFood = await _dbcontext.FoodExchange
                .FirstOrDefaultAsync(m => m.FoodExchangeID == id);
            if (DietFood == null)
            {
                return NotFound();
            }

            return View(DietFood);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var DietFood = await _dbcontext.FoodExchange.FindAsync(id);
            _dbcontext.FoodExchange.Remove(DietFood);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { DietFood.PatientInfoID });
        }

        private bool DietFoodExists(int id)
        {
            return _dbcontext.FoodExchange.Any(e => e.FoodExchangeID == id);
        }
    }
}
