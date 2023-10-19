using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class FertilityDataViewModel
    {

        [Required(ErrorMessage = "Please enter the length of your menstrual cycle.")]
        [Range(20, 45, ErrorMessage = "Menstrual cycle length must be between 20 and 45 days.")]
        public int MenstrualCycleLength { get; set; }

        [Required(ErrorMessage = "Please enter your last menstrual period start date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Last Menstrual Period Start Date")]
        public DateTime LastMenstrualPeriodStartDate { get; set; }

        // Add more properties for collecting additional fertility tracking data:
        // For example:
        // [Display(Name = "Basal Body Temperature (BBT)")]
        // public decimal BasalBodyTemperature { get; set; }
        //
        // [Display(Name = "Cervical Mucus Consistency")]
        // public string CervicalMucus { get; set; }
        //
        // [Display(Name = "Other Fertility Indicators")]
        // public string OtherIndicators { get; set; }
    }
}
