using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class Counselor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Add counselor-related properties
        public string? ContactInformation { get; set; }
        public string? Specialization { get; set; }
        // Add more properties as needed.
    }
}
