using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;




namespace E_NompiloPhc.Controllers.Nutrition
{
    public class FoodItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodItems
        public async Task<IActionResult> Index()
        {
            return _context.FoodItems != null ?
                        View(await _context.FoodItems.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.FoodItems'  is null.");
        }

        // GET: FoodItems/Details/5
        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            //if (id == null || _context.FoodItems == null)
            //{
            //    return NotFound();
            //}

            var foodItems = await _context.FoodItems
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (foodItems == null)
            {
                return NotFound();
            }

            return View(foodItems);
        }

        // GET: FoodItems/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
            return View();
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PatientInfoID, [Bind("FoodID,FoodName,Category,ServingSize,Calories,Carbohydrates,Protein,Fat,Fiber,Vitamins,Minerals")] FoodItems foodItems)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                foodItems.PatientInfoID = PatientInfoID;
                _context.Add(foodItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodItems);
        }

        // GET: FoodItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodItems == null)
            {
                return NotFound();
            }

            var foodItems = await _context.FoodItems.FindAsync(id);
            if (foodItems == null)
            {
                return NotFound();
            }
            return View(foodItems);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodID,FoodName,Category,ServingSize,Calories,Carbohydrates,Protein,Fat,Fiber,Vitamins,Minerals")] FoodItems foodItems)
        {
            ViewBag.PatientInfoID = foodItems.PatientInfoID;
            if (id != foodItems.FoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodItemsExists(foodItems.FoodID))
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
            return View(foodItems);
        }

        // GET: FoodItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodItems == null)
            {
                return NotFound();
            }

            var foodItems = await _context.FoodItems
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (foodItems == null)
            {
                return NotFound();
            }

            return View(foodItems);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FoodItems'  is null.");
            }
            var foodItems = await _context.FoodItems.FindAsync(id);
            if (foodItems != null)
            {
                _context.FoodItems.Remove(foodItems);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodItemsExists(int id)
        {
            return (_context.FoodItems?.Any(e => e.FoodID == id)).GetValueOrDefault();
        }
    }
}
