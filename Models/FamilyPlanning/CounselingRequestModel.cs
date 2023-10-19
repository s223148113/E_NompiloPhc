using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class CounselingRequestModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string RequestDetails { get; set; }

        // Add other counseling request-related properties
    }
}
