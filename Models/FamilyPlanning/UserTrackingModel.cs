namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class UserTrackingModel
    {
        public int Id { get; set; } // An identifier for the tracking entry (if needed)
        public string UserId { get; set; } // The user's identifier, linking the data to the user
        public DateTime TrackingDate { get; set; } // The date of the tracking entry
        public int MenstrualCycleDay { get; set; } // The day of the menstrual cycle
        public double BasalBodyTemperature { get; set; } // The basal body temperature for that day
        public bool HasOvulationTest { get; set; } // Whether an ovulation test was taken (true/false)
                                                   // Add more properties as needed to capture other relevant tracking data
    }
}
