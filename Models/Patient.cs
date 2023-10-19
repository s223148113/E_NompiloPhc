using E_NompiloPhc.Models.FamilyPlanning;
using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Add other patient-related properties as needed

        // Navigation property to Appointments
        public ICollection<Appointment> Appointments { get; set; }

        public List<FertilityData> FertilityTrackings { get; set; }
        public List<CounselingRequestModel> CounselingRequests { get; set; }
    }
}
