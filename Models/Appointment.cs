using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.FamilyPlanning;

namespace E_NompiloPhc.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string UserId { get; set; } // Foreign key to the user
        public int CounselorId { get; set; } // Foreign key to the counselor
        public DateTime AppointmentDate { get; set; }
        public string AdditionalNotes { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Counselor Counselor { get; set; }
    }
}
