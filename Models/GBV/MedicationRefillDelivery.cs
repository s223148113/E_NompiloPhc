using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.GBV
{
    public class MedicationRefillDelivery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //search patient by email to see address
        public string PatientEmail { get; set; }
    }
}
