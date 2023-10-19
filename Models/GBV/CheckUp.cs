using System.ComponentModel.DataAnnotations;

namespace E_NompiloPhc.Models.GBV
{
    public class CheckUp
    {
        public int Id { get; set; }
        [Required]

        public string PatientLastName { get; set; }
        [Required]
        public string PatientFirstName { get; set; }
        [Required]
        public int BodyTemperature { get; set; }
        [Required]
        public string OxygenLevel { get; set; }
        [Required]

        public int PulseRate { get; set; }
        [Required]

        public int Weight { get; set; }
        [Required]

        public int BloodPressure { get; set; }
        [Required]

        public string Diagnosis { get; set; }
        [Required]

        public string Therapy { get; set; }
        [Required]

        public string AssignedMedication { get; set; }
        [Required]
        public string CheckUpNurse { get; set; }
        [Required]

        public string AssignedDoctor { get; set; }
        [Required]

        [Display(Name = "Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? Date { get; set; }
    }
}
