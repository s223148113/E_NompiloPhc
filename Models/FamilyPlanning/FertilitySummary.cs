namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class FertilitySummary
    {
        public DateTime OvulationDate { get; set; }

        public List<DateTime> FertileDays { get; set; }

        public double BasalBodyTempAverage { get; set; }

        public double CervicalMucusAverage { get; set; }

        public int CyclesAnalyzed { get; set; }

        public DateTime NextPeriodDate { get; set; }

        public int TypicalCycleLength { get; set; }

        public List<FertilityData> FertilityData { get; set; }

        // Constructor
        public FertilitySummary()
        {
            FertileDays = new List<DateTime>();
            FertilityData = new List<FertilityData>();
        }
    }

}

