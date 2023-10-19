using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class ContraceptivePreferencesViewModel
    {
        [Required(ErrorMessage = "Please enter your age.")]
        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
        public int UserAge { get; set; }
        public string SelectedContraceptive { get; set; }

        public List<Contraceptive> AvailableContraceptives { get; set; }
    }
}
