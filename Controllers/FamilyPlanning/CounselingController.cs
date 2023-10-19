using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPhc.Controllers.FamilyPlanning
{
    public class CounselingController : Controller
    {
        private readonly ApplicationDbContext db;

        public CounselingController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // Action to display a list of available counselors.
        public ActionResult FindCounselor()
        {
            var counselors = db.Counselors.ToList();
            return View(counselors);
        }

        // Action to display a form for scheduling an appointment with a counselor.
        public ActionResult ScheduleAppointment(int counselorId)
        {
            var counselor = db.Counselors.Find(counselorId);

            if (counselor != null)
            {
                var model = new AppointmentViewModel
                {
                    CounselorId = counselor.Id,
                    CounselorName = counselor.Name,
                    AppointmentDate = DateTime.Today.AddDays(1) // Set a default appointment date (e.g., for tomorrow).
                };

                return View(model);
            }

            // Handle the case where the selected counselor is not found.
            return HttpNotFound();
        }

        // Process appointment booking, notify the counselor, and confirm the booking.
        [HttpPost]
        public ActionResult BookAppointment(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the appointment to the database
                db.Appointments.Add(new Appointment
                {
                    CounselorId = model.CounselorId,
                    AppointmentDate = model.AppointmentDate,
                    AdditionalNotes = model.AdditionalNotes
                    // Populate other appointment properties as needed
                });
                db.SaveChanges();

                ViewBag.Message = "Appointment booked successfully!";
                return View("Confirmation");
            }

            // If the model is not valid, redisplay the appointment form with validation errors.
            return View("ScheduleAppointment", model);
        }

        // Action to display a counselor's profile.
        public ActionResult CounselorProfile(int counselorId)
        {
            var counselor = db.Counselors.Find(counselorId);

            if (counselor != null)
            {
                return View(counselor);
            }

            // Handle the case where the counselor with the specified ID is not found.
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
