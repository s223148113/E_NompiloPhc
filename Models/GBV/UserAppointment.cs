using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPhc.Models.GBV
{
    public class UserAppointment
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string ReasonForVisit { get; set; }
        [Required]
        public string Consulatation { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public int PhoneNumber { get; set; }
        [Required]

        [Display(Name = "Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Time { get; set; }
    }
}
