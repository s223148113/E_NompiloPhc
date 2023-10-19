using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.Nutrition
{
    public class BiochemicalsController1 : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BiochemicalsController1(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int? PatientInfoID)
        {
            var BiochemicalsRecord = _dbContext.Biochemicals
                 .FirstOrDefault(Q => Q.PatientInfoID == PatientInfoID);

            if (BiochemicalsRecord == null)
            {
                // Handle the case where no record is found
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            ViewBag.PatientInfoID = PatientInfoID; // Pass the PatientInfoID to the view

            return View(BiochemicalsRecord);
        }

        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbContext.Biochemicals == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = PatientInfoID;
            var bio = await _dbContext.Biochemicals
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (bio == null)
            {
                return RedirectToAction(nameof(Create), new { PatientInfoID });
            }

            return View(bio);
        }

        // GET: Biochemical/Create
        public IActionResult Create(int? PatientInfoID)
        {
            ViewBag.PatientInfoID = PatientInfoID;
            ViewData["PatientInfoID"] = PatientInfoID;
            return View();
        }

        // POST: Biochemical/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PatientInfoID, [Bind("BioID,SmokingFrequency,uricAcid,cholesterol,totalProtein,albumin,globulin,amylase,lipase,hemoglobin,sodium,potassium,calcium,magnesium,ammonia,bleedingTime,clottingTime,PatientInfoID")] Biochemicals biochemicals)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = PatientInfoID;
                biochemicals.PatientInfoID = PatientInfoID;

                _dbContext.Add(biochemicals);
                await _dbContext.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Details), new { PatientInfoID });
            //ViewData["PatientInfoID"] =  sGA.PatientInfoID;
            //return View(biochemicals);
        }

        public async Task<IActionResult> Edit(int? BiochemicalID)
        {
            if (BiochemicalID == null || _dbContext.Biochemicals == null)
            {
                return NotFound();
            }


            var bio = await _dbContext.Biochemicals.FirstOrDefaultAsync(p => p.BioID == BiochemicalID);
            if (bio == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = bio.PatientInfoID;

            return View(bio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int BiochemicalID, [Bind("BioID,SmokingFrequency,uricAcid,cholesterol,totalProtein,albumin,globulin,amylase,lipase,hemoglobin,sodium,potassium,calcium,magnesium,ammonia,bleedingTime,clottingTime")] Biochemicals bio)
        {
            if (BiochemicalID != bio.BioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(bio);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioExists(bio.BioID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            ViewBag.PatientInfoID = bio.PatientInfoID;
            ViewData["PatientInfoID"] = bio.PatientInfoID;
            return View(bio);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbContext.Biochemicals == null)
            {
                return NotFound();
            }

            var bio = await _dbContext.Biochemicals
                .Include(s => s.PatientInfo)
                .FirstOrDefaultAsync(m => m.BioID == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbContext.Biochemicals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Biochemicals'  is null.");
            }
            var bio = await _dbContext.Biochemicals.FindAsync(id);
            if (bio != null)
            {
                _dbContext.Biochemicals.Remove(bio);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }
        private bool BioExists(int id)
        {
            return (_dbContext.Biochemicals?.Any(e => e.BioID == id)).GetValueOrDefault();
        }
    }
}
