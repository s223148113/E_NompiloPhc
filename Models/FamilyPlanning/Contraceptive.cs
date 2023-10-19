using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class Contraceptive
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        // Add contraceptive-related properties
        public string? Effectiveness { get; set; }
        public string? SideEffects { get; set; }
        public string? UsageInstructions { get; set; }
        // Add more properties as neede
    }
}
