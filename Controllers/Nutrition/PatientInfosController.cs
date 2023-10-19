﻿using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.Nutrition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_NompiloPhc.Controllers.Nutrition
{
    public class PatientInfosController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public PatientInfosController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: PatientInfos
        public async Task<IActionResult> Index()
        {
            ViewBag.PatientInfoID = null;
            return _dbcontext.PatientInfos != null ?
                        View(await _dbcontext.PatientInfos.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.PatientInfo'  is null.");

        }

        // GET: PatientInfos/Details/5
        public async Task<IActionResult> Details(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.PatientInfos == null)
            {
                return NotFound();
            }
            ViewBag.PatientInfoID = PatientInfoID;
            var patientInfo = await _dbcontext.PatientInfos
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (patientInfo == null)
            {
                return NotFound();
            }

            return View(patientInfo);
        }

        public IActionResult Details2(int? PatientInfoID)
        {
            PatientInfo patientInfo = _dbcontext.PatientInfos.FirstOrDefault(p => p.PatientInfoID == PatientInfoID);
            ViewData["PatientInfoID"] = PatientInfoID;
            ViewBag.PatientInfoID = PatientInfoID;
            return View(patientInfo);
        }

        // GET: PatientInfos/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: PatientInfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientInfoID,FirstName,LastName,Sex,Birthday,Address,ContactNumber,Citizenship,Ward,Room,AttendingDoctor,Dietitian,NextOfKin,NextOfKinNumber,AdmissionDate")] PatientInfo patientInfo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PatientInfoID = patientInfo.PatientInfoID;
                _dbcontext.Add(patientInfo);
                await _dbcontext.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
            }
            return View(patientInfo);
        }


        // GET: PatientInfos/Edit/5
        public async Task<IActionResult> Edit(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.PatientInfos == null)
            {
                return NotFound();
            }

            var patientInfo = await _dbcontext.PatientInfos.FirstOrDefaultAsync(p => p.PatientInfoID == PatientInfoID);
            if (patientInfo == null)
            {
                return NotFound();
            }
            return View(patientInfo);
        }

        // POST: PatientInfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int PatientInfoID, [Bind("PatientInfoID,FirstName,LastName,Sex,Birthday,Address,ContactNumber,Citizenship,Ward,Room,AttendingDoctor,Dietitian,NextOfKin,NextOfKinNumber,AdmissionDate")] PatientInfo patientInfo)
        {
            if (PatientInfoID != patientInfo.PatientInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(patientInfo);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientInfoExists(patientInfo.PatientInfoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details2));
            }
            return View(patientInfo);
        }

        // GET: PatientInfos/Delete/5
        public async Task<IActionResult> Delete(int? PatientInfoID)
        {
            if (PatientInfoID == null || _dbcontext.PatientInfos == null)
            {
                return NotFound();
            }

            var patientInfo = await _dbcontext.PatientInfos
                .FirstOrDefaultAsync(m => m.PatientInfoID == PatientInfoID);
            if (patientInfo == null)
            {
                return NotFound();
            }

            return View(patientInfo);
        }

        // POST: PatientInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int PatientInfoID)
        {
            if (_dbcontext.PatientInfos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PatientInfo'  is null.");
            }
            var patientInfo = await _dbcontext.PatientInfos.FirstOrDefaultAsync(p => p.PatientInfoID == PatientInfoID);
            if (patientInfo != null)
            {
                _dbcontext.Remove(patientInfo);
            }

            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }

        private bool PatientInfoExists(int PatientInfoID)
        {
            return (_dbcontext.PatientInfos?.Any(e => e.PatientInfoID == PatientInfoID)).GetValueOrDefault();
        }
    }
}
