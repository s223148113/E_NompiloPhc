using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.GBV
{
    public class PatientMedicationRefill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        public string MedicationName { get; set; }
        [Required]
        public string ImprintCode { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public string Shape { get; set; }

        public string AssignedDoctor { get; set; }

        [Required]
        [Display(Name = "Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? Date { get; set; }
    }
}
