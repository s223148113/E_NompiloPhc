using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.FamilyPlanning;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPhc.Controllers.FamilyPlanning
{
    public class FamilyPlanningController : Controller
    {
        private readonly ApplicationDbContext _context; // Replace with your DbContext

        public FamilyPlanningController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       

        // Action to display a list of contraceptive methods.
        public IActionResult ContraceptiveMethods()
        {
            // Retrieve a list of contraceptive methods from the database.
            List<ContraceptiveMethod> contraceptiveMethods = _context.ContraceptiveMethods.ToList();

            // Pass the list to the view.
            return View(contraceptiveMethods);
        }

    }
}
