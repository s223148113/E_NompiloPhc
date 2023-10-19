using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class FertilityData
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        // Add fertility data properties
        public DateTime CycleStartDate { get; set; }

        public double BasalBodyTemperature { get; set; }
        public string CervicalMucusQuality { get; internal set; }
        public DateTime Date { get; internal set; }
        public int UserId { get; internal set; }
    }
}
