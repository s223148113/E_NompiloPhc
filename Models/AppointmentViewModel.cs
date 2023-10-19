using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPhc.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public string CounselorsName { get; set; }

        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "Please enter the appointment date.")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Additional Notes")]
        [StringLength(500, ErrorMessage = "Additional notes should not exceed 500 characters.")]
        public string AdditionalNotes { get; set; }
        public int CounselorId { get; internal set; }
        public string? CounselorName { get; internal set; }
    }
}
