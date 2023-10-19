using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Date of Birth field is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Other properties specific to patient views...

        // Additional properties can be added as needed to capture data for the view.
    }
}
