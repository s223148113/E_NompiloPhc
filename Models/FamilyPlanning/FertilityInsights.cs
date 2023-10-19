namespace E_NompiloPhc.Models.FamilyPlanning
{
    public class FertilityInsights
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string InsightsText { get; set; }
        public string FertileDays { get; set; }
        // Add more properties as needed.
    }
}
