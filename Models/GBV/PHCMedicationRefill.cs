using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_NompiloPhc.Models.GBV
{
    public class PHCMedicationRefill
    {
        [Key]
        public int Id { get; set; }
        public string PharmacistName { get; set; }
        [Required]
        public string PharmacistLastName { get; set; }
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
        public string Department { get; set; }
        [Required]
        public string MedicationSupplier { get; set; }
        [Required]


        [Display(Name = "Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? Date { get; set; }
    }
}
