using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.Nutrition
{
    public class FoodExchangeController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public FoodExchangeController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IActionResult> Index(int patientInfoID)
        {
            if (patientInfoID == null)
            {
                return NotFound();
            }

            var foodExchange = await _dbcontext.FoodExchange
                .Where(fh => fh.PatientInfoID == patientInfoID)
                .ToListAsync();

            ViewBag.PatientInfoID = patientInfoID;
            return View(foodExchange);
        }

        //public async Task<IActionResult> Index()
        //{
        //    return _dbcontext.FoodExchange != null ?
        //                 View(await _dbcontext.FoodExchange.ToListAsync()) :
        //                 Problem("Entity set 'ApplicationDbContext.FoodExchange'  is null.");

        //}

        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.FoodExchange == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = PatientInfoID;
            var foodExchange = await _dbcontext.FoodExchange
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (foodExchange == null)
            {
                return NotFound();
            }

            return View(foodExchange);
        }
        public IActionResult Create(int PatientInfoID)
        {
            //var patientInfo = _dbcontext.PatientInfos.FirstOrDefault(p => p.PatientInfoID == PatientInfoID);
            //if (patientInfo == null)
            //{
            //    return NotFound();
            //}

            //var foodExchange = new FoodExchange
            //{
            //    PatientInfo = patientInfo
            //};

            //return View(foodExchange);

            ViewBag.PatientInfoID = PatientInfoID;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create(FoodExchange model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbcontext.FoodExchange.Add(model);
        //        _dbcontext.SaveChanges();
        //        return RedirectToAction("Index", "FoodExchange");
        //    }

        //    return View(model);
        //}
        public async Task<IActionResult> Create(int PatientInfoID, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems, PatientInfoID")] FoodExchange foodExchange)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                foodExchange.PatientInfoID = PatientInfoID;

                _dbcontext.Add(foodExchange);
                await _dbcontext.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index), new { PatientInfoID });
            //ViewData["PatientInfoID"] =  sGA.PatientInfoID;  
            //return View(foodExchange);
        }

        public async Task<IActionResult> Edit(int? FoodExchangeID)
        {
            if (FoodExchangeID == null || _dbcontext.FoodExchange == null)
            {
                return NotFound();
            }


            var foodExchange = await _dbcontext.FoodExchange.FirstOrDefaultAsync(p => p.FoodExchangeID == FoodExchangeID);
            if (foodExchange == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = foodExchange.PatientInfoID;
            ViewData["PatientInfoID"] = foodExchange.PatientInfoID;
            return View(foodExchange);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int FoodExchangeID, [Bind("FoodExchangeID,DietDiscription,Breakfast,AMSnack,Lunch,PMSnack,DinnerSupper,TotalItems,PatientInfoID")] FoodExchange foodExchange)
        {
            if (FoodExchangeID != foodExchange.FoodExchangeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(foodExchange);
                    await _dbcontext.SaveChangesAsync();
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
            ViewBag.PatientInfoID = foodExchange.PatientInfoID;
            ViewData["PatientInfoID"] = foodExchange.PatientInfoID;
            return View(foodExchange);
        }
        private bool FoodExchangeExists(int id)
        {
            return (_dbcontext.FoodExchange?.Any(e => e.FoodExchangeID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbcontext.SGA == null)
            {
                return NotFound();
            }

            var foodExchange = await _dbcontext.FoodExchange
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.FoodExchangeID == id);
            if (foodExchange == null)
            {
                return NotFound();
            }

            return View(foodExchange);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbcontext.FoodExchange == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FoodExchange'  is null.");
            }
            var foodExchange = await _dbcontext.FoodExchange.FindAsync(id);
            if (foodExchange != null)
            {
                _dbcontext.FoodExchange.Remove(foodExchange);
            }

            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ViewBag.PatientInfoID });
        }
    }
}
